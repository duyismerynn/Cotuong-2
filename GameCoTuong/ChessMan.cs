using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCoTuong
{
    class ChessMan
    {
        public bool isAlive = true;
        public int x=-1, y=-1;
        public string mau;
        public string loai;
        public List<Point> listO = new List<Point>();

        public void TinhOCoTheDi()
        {
            Point oTemp = new Point(-1,-1);

            if (mau == "Xanh")
            {
                if (loai == "Tot")
                {
                    oTemp.X = x;
                    oTemp.Y = y + 1;
                    listO.Add(oTemp);
                    return;
                }
                if (loai == "Ma")
                {

                    

                    oTemp = TinhNuoc( 2, 1); //+2 +1

                    addList(oTemp, listO);

                    oTemp = TinhNuoc( 2, -1); //+2 -1

                    addList(oTemp, listO);

                    oTemp = TinhNuoc( -2, 1); //-2 +1

                    addList(oTemp, listO);

                    oTemp = TinhNuoc( -2, -1); //-2 -1

                    addList(oTemp, listO);

                    oTemp = TinhNuoc( 1, 2); //+1 +2

                    addList(oTemp, listO);

                    oTemp = TinhNuoc( 1, -2); //+1 -2

                    addList(oTemp, listO);

                    oTemp = TinhNuoc( -1, 2); //-1 +2

                    addList(oTemp, listO);

                    oTemp = TinhNuoc( -1, -2); //-1 -2

                    addList(oTemp, listO);

                    return;

                }
                if (loai == "Phao" || loai =="Xe")
                {
                    for (int _x=0; _x < 9; _x++)
                    {
                        if (_x != x)
                        {
                            oTemp.X = _x;
                            oTemp.Y = y;
                            addList(oTemp, listO);
                        }             
                    }
                    for (int _y = 0; _y < 10; _y++)
                    {
                        if (_y != y)
                        {
                            oTemp.X = x;
                            oTemp.Y = _y;
                            addList(oTemp, listO);
                        }
                    }
                    return;
                }
                if (loai == "Tinh")
                {
                    oTemp = TinhNuoc(2, 2);
                    addList(oTemp, listO);

                    oTemp = TinhNuoc(2, -2);
                    addList(oTemp, listO);

                    oTemp = TinhNuoc(-2, -2);
                    addList(oTemp, listO);

                    oTemp = TinhNuoc(-2, 2);
                    addList(oTemp, listO);

                    return;
                }
                if (loai == "Sy")
                {
                    oTemp = TinhNuoc(1, 1);
                    addList(oTemp, listO);

                    oTemp = TinhNuoc(1, -1);
                    addList(oTemp, listO);

                    oTemp = TinhNuoc(-1, 1);
                    addList(oTemp, listO);

                    oTemp = TinhNuoc(-1, -1);
                    addList(oTemp, listO);
                    return;
                }
                if (loai == "Tuong")
                {
                    oTemp = TinhNuoc(1, 0);
                    addList(oTemp, listO);

                    oTemp = TinhNuoc(-1, 0);
                    addList(oTemp, listO);

                    oTemp = TinhNuoc(0, 1);
                    addList(oTemp, listO);

                    oTemp = TinhNuoc(0, -1);
                    addList(oTemp, listO);
                    return;
                }
            }      
        }
        Point TinhNuoc(  int _x, int _y)
        {
            Point temp = new Point(-1, -1);
            temp.X = x + _x;
            temp.Y = y + _y;
            return temp;
        }
        void addList(Point temp, List<Point> a)
        {
            if (temp.X >= 0 && temp.Y >= 0)
            {
                a.Add(temp);
                //MessageBox.Show(temp.X.ToString(), temp.Y.ToString());

            }
        }

    }
}
