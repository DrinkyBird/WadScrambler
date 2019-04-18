using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace WadScrambler
{
    class WadEntry
    {
        public int FilePos;
        public int Size;
        public string Name;
        public long MetaPos;
    }

    class WadFile
    {
        private static readonly string[] START_MARKERS = new string[] {
            "F_START",
            "FF_START",
            "S_START",
            "SS_START",
            "P_START",
            "PP_START",
        };

        private static readonly string[] END_MARKERS = new string[] {
            "F_END",
            "FF_END",
            "S_END",
            "SS_END",
            "P_END",
            "PP_END",
        };

        public string FileName { get; private set; }

        public List<WadEntry> Lumps = new List<WadEntry>();

        public List<WadEntry> Sprites = new List<WadEntry>();
        public List<WadEntry> Flats = new List<WadEntry>();
        public List<WadEntry> Patches = new List<WadEntry>();
        public List<WadEntry> MiscGraphics = new List<WadEntry>();
        public List<WadEntry> AllGraphics = new List<WadEntry>();
        public List<WadEntry> Sounds = new List<WadEntry>();
        public List<WadEntry> Music = new List<WadEntry>();

        public WadFile(string filename)
        {
            this.FileName = filename;
        }

        private string ReadString(BinaryReader reader, int numChars)
        {
            string s = string.Empty;

            for (int i = 0; i < numChars; i++)
            {
                s += (char)reader.ReadSByte();
            }

            return s;
        }

        private string ReadLumpName(BinaryReader reader)
        {
            long pos = reader.BaseStream.Position;

            int len = 0;

            for (int i = 0; i < 8; i++)
            {
                sbyte c = reader.ReadSByte();
                if (c == 0x00)
                {
                    break;
                }

                len++;
            }

            reader.BaseStream.Seek(pos, SeekOrigin.Begin);

            string s = ReadString(reader, len);

            reader.BaseStream.Seek(pos + 8, SeekOrigin.Begin);

            return s;
        }

        public void Read()
        {
            using (FileStream stream = new FileStream(FileName, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                stream.Seek(0, SeekOrigin.Begin);

                string magic = ReadString(reader, 4);

                if (magic != "PWAD" && magic != "IWAD")
                {
                    throw new InvalidDataException("Invalid WAD header (expected PWAD or IWAD, got " + magic + ")");
                }

                int numLumps = reader.ReadInt32();
                int infoTableOfs = reader.ReadInt32();

                if (numLumps < 0)
                {
                    throw new InvalidDataException("numLumps < 0");
                }

                if (infoTableOfs < 0)
                {
                    throw new InvalidDataException("infoTableOfs < 0");
                }

                Lumps.Clear();
                Lumps.Capacity = numLumps;

                stream.Seek(infoTableOfs, SeekOrigin.Begin);

                string section = string.Empty;

                for (int i = 0; i < numLumps; i++)
                {
                    WadEntry entry = new WadEntry
                    {
                        MetaPos = stream.Position,
                        FilePos = reader.ReadInt32(),
                        Size = reader.ReadInt32(),
                        Name = ReadLumpName(reader)
                    };

                    if (entry.FilePos < 12 && entry.Size > 0)
                    {
                        throw new InvalidDataException("filePos < 12 (for lump " + entry.Name + ")");
                    }

                    if (entry.Size < 0)
                    {
                        throw new InvalidDataException("size < 0 (for lump " + entry.Name + ")");
                    }

                    if (IsStartMarker(entry.Name))
                    {
                        section = entry.Name;
                        continue;
                    }
                    else if (IsEndMarker(entry.Name))
                    {
                        section = string.Empty;
                        continue;
                    }

                    if (entry.Size < 1)
                    {
                        continue;
                    }

                    Lumps.Add(entry);

                    switch (section)
                    {
                        case "F_START":
                        case "FF_START":
                        {
                            Flats.Add(entry);
                            break;
                        }
                        case "S_START":
                        case "SS_START":
                        {
                            Sprites.Add(entry);
                            AllGraphics.Add(entry);
                            break;
                        }
                        case "P_START":
                        case "PP_START":
                        {
                            Patches.Add(entry);
                            AllGraphics.Add(entry);
                            break;
                        }
                    }

                    if (entry.Name.StartsWith("DS"))
                    {
                        Sounds.Add(entry);
                    } 
                    else if (IsMiscGraphic(entry))
                    {
                        MiscGraphics.Add(entry);
                        AllGraphics.Add(entry);
                    }
                    else if (entry.Name.StartsWith("D_"))
                    {
                        Music.Add(entry);
                    }
                }

                Console.WriteLine("Read WAD file. Total " + Lumps.Count + " lumps");
                Console.WriteLine("\tSprites " + Sprites.Count);
                Console.WriteLine("\tPatches " + Patches.Count);
                Console.WriteLine("\tFlats " + Flats.Count);
            }
        }

        public void WriteEntries()
        {
            using (FileStream stream = new FileStream(FileName, FileMode.Open))
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                for (int i = 0; i < Lumps.Count; i++)
                {
                    WadEntry lump = Lumps[i];

                    stream.Seek(lump.MetaPos, SeekOrigin.Begin);
                    writer.Write(lump.FilePos);
                    writer.Write(lump.Size);
                }
            }
        }

        public int ScrambleEntries(ref List<WadEntry> list)
        {
            int scrambledEntries = 0;

            Random r = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < list.Count; i++)
            {
                int i0 = r.Next(list.Count);

                int i1;

                // ensure we pick a different lump
                do
                {
                    i1 = r.Next(list.Count);
                } while (list.Count >= 2 && list[i1].Name == list[i0].Name);

                // some ports (ie zdoom) will crash if the player sprite
                // is incorrectly sized
                if (list[i0].Name.StartsWith("PLAY") || list[i1].Name.StartsWith("PLAY"))
                {
                    continue;
                }

                int pos0 = list[i0].FilePos;
                int pos1 = list[i1].FilePos;

                int size0 = list[i0].Size;
                int size1 = list[i1].Size;

                list[i0].FilePos = pos1;
                list[i0].Size = size1;

                list[i1].FilePos = pos0;
                list[i1].Size = size0;

                scrambledEntries++;
            }

            return scrambledEntries;
        }

        private static bool IsStartMarker(string name)
        {
            foreach (var s in START_MARKERS)
            {
                if (name.Equals(s))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsEndMarker(string name)
        {
            foreach (var s in END_MARKERS)
            {
                if (name.Equals(s))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsMiscGraphic(WadEntry entry)
        {
            if (Patches.Contains(entry) || Flats.Contains(entry) || Sprites.Contains(entry))
            {
                return false;
            }

            if (entry.Name.StartsWith("M_") || entry.Name.StartsWith("BRDR") || entry.Name.StartsWith("WIP") || entry.Name.StartsWith("WIA0") || entry.Name.StartsWith("WIA1") || entry.Name.StartsWith("WIA2") || entry.Name.StartsWith("ST"))
            {
                return true;
            }

            return false;
        }
    }
}
