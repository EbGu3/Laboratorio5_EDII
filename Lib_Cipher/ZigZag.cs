using System.Collections.Generic;
using System.Linq;

namespace Lib_Cipher
{
    public class Caracter
    {
        public List<byte> Car_List = new List<byte>();
    }

    public class ZigZag
    {
        public byte[] Cipher(byte[] txt, int levels)
        {
            Dictionary<int, Caracter> level_Dic = new Dictionary<int, Caracter>();
            List<byte> bytes_Exist = new List<byte>();
            var count = 0;
            while (count < levels)
            {
                var ini_List = new List<byte>();
                level_Dic.Add(count + 1, new Caracter
                {
                    Car_List = ini_List
                });
                count++;
            }

            var posLevel = 1;
            var elev = false;
            foreach (var item in txt)
            {
                if (!bytes_Exist.Contains(item))
                {
                    bytes_Exist.Add(item);
                }
                level_Dic.ElementAt(posLevel - 1).Value.Car_List.Add(item);
                if (!elev)
                {
                    if (posLevel == levels)
                    {
                        posLevel--;
                        elev = true;
                    }
                    else
                    {
                        posLevel++;
                    }
                }
                else
                {
                    if (posLevel == 1)
                    {
                        posLevel++;
                        elev = false;
                    }
                    else
                    {
                        posLevel--;
                    }
                }
            }
            byte filler = 36;
            if (!bytes_Exist.Contains(36))
            {
                filler = 254;
                while (bytes_Exist.Contains(filler))
                {
                    filler--;
                }
            }
            var caracteresExtra = 0;
            while (posLevel - 1 != 1)
            {
                caracteresExtra++;
                level_Dic.ElementAt(posLevel - 1).Value.Car_List.Add(filler);
                if (!elev)
                {
                    if (posLevel == levels)
                    {
                        posLevel--;
                        elev = true;
                    }
                    else
                    {
                        posLevel++;
                    }
                }
                else
                {
                    if (posLevel == 1)
                    {
                        posLevel++;
                        elev = false;
                    }
                    else
                    {
                        posLevel--;
                    }
                }

            }
            var cipherTxt = new byte[txt.Length + caracteresExtra];
            var ladder = 0;
            var pos = 0;
            while (ladder < levels)
            {
                foreach (var item in level_Dic.ElementAt(ladder).Value.Car_List)
                {
                    cipherTxt[pos] = item;
                    pos++;
                }

                ladder++;
            }

            return cipherTxt;
        }

		public byte[] Decipher(byte[] txt, int level)
		{
			Dictionary<int, Caracter> level_Dic = new Dictionary<int, Caracter>();
			int count = 0;
			while (count < level)
			{
				var indexList = new List<byte>();
				level_Dic.Add(count + 1, new Caracter
				{
					Car_List = indexList
				});
				count++;
			}
			int min = (4 * (level - 1)) + 1;
			int newUv = (level * 2) - 2;
			int pic = (level - 2) * 2;
            int relLenght;
            if (txt.Length <= min)
			{
				relLenght = min;
			}
			else
			{
				int otherElem = txt.Length - min;
				int repUv = otherElem / newUv;
				if (otherElem % newUv != 0)
				{
					repUv++;
				}
				relLenght = min + (repUv * newUv);
			}
			int MaxPic = (relLenght + 1 + pic) / (2 + pic);
			int midValue = (2 * (MaxPic - 1));
			int LowPic = MaxPic - 1;
			int midLevel = level - 2;
			int auxLevel = midLevel;
			int countLevel = midValue;

			foreach (var item in txt)
			{
				if (MaxPic > 0)
				{
					level_Dic.ElementAt(0).Value.Car_List.Add(item);
					MaxPic--;
				}
				else if (MaxPic == 0 && auxLevel > 0)
				{
					level_Dic.ElementAt((midLevel - auxLevel) + 1).Value.Car_List.Add(item);
					countLevel--;
					if (countLevel == 0 && midLevel > 0)
					{
						auxLevel--;
						countLevel = midValue;
					}
				}
				else if (MaxPic == 0 && auxLevel == 0)
				{
					level_Dic.ElementAt(level - 1).Value.Car_List.Add(item);
				}
			}
			var DecipherTxt = new byte[txt.Length];

			var pos = 0;
			var posLevel = 1;
			bool elev = false;
			bool middle = false;
			var posValueArr = 0;
			var counter = txt.Length;
			while (counter > 0)
			{
				if (middle)
				{
					if (!elev)
					{
						DecipherTxt[pos] = level_Dic.ElementAt(posLevel - 1).Value.Car_List.ElementAt(posValueArr * 2);
						pos++;
					}
					else
					{
						DecipherTxt[pos] = level_Dic.ElementAt(posLevel - 1).Value.Car_List.ElementAt((posValueArr * 2) + 1);
						pos++;
					}
				}
				else
				{
					DecipherTxt[pos] = level_Dic.ElementAt(posLevel - 1).Value.Car_List.ElementAt(posValueArr);
					pos++;
				}
				if (!elev)
				{
					if (posLevel != level)
					{
						if (posLevel + 1 == level)
						{
							middle = false;
						}
						else if (posLevel == 1)
						{
							middle = true;
						}
						posLevel++;
					}
					else
					{
						posLevel--;
						elev = true;
						middle = true;
					}
				}
				else
				{
					if (posLevel != 1)
					{
						if (posLevel - 1 == 1)
						{
							middle = false;
							posValueArr++;

						}
						else if (posLevel == level)
						{
							middle = true;
						}
						posLevel--;
					}
					else
					{
						posLevel++;
						elev = false;
						middle = true;
					}
				}
				counter--;
			}
			return DecipherTxt;
		}
	}
}
