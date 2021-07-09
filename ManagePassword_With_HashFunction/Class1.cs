using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace ManagePassword_With_HashFunction
{
    public class Manage_Password
    {
        

      // function create password with option (Upper,Lower,number,Total,sort) -- 2 overload
        public string New_password(int total = 0, int upper = 0, int lower = 0, int num = 0)
        {

            try
            {


                var string_set = new StringBuilder(total);
                // create upper case

                if (total > 0)
                {

                    if (upper > 0)
                    {
                        for (int i = 0; i < upper; i++)
                        {

                            Random Rnd_upper = new Random();

                            int num_upper = Rnd_upper.Next(65, 90);

                            // หน่วงเวลาเพื่อรอ ให้ Process การสุ่มตัวเลขใน step ก่อนหน้าทำเสร็จก่อน
                            Thread.Sleep(20);

                            char chr_upper = (char)num_upper;
                            string_set.Append(chr_upper);
                        }


                    }
                    // create lower case

                    if (lower > 0)
                    {

                        for (int i = 0; i < lower; i++)
                        {
                            Random Rnd_lower = new Random();
                            int num_lower = Rnd_lower.Next(97, 122);

                            // หน่วงเวลาเพื่อรอ ให้ Process การสุ่มตัวเลขใน step ก่อนหน้าทำเสร็จก่อน

                            Thread.Sleep(20);
                            char chr_lower = (char)num_lower;
                            string_set.Append(chr_lower);




                        }



                    }

                    // create number 

                    if (num > 0)
                    {
                        for (int i = 0; i < num; i++)
                        {
                            Random Rnd_upper = new Random();
                            int num_upper = Rnd_upper.Next(0, 9);

                            // หน่วงเวลาเพื่อรอ ให้ Process การสุ่มตัวเลขใน step ก่อนหน้าทำเสร็จก่อน

                            Thread.Sleep(20);
                            string_set.Append(num_upper.ToString());
                        }
                    }

                    // sort ให้ข้อมูลไม่จัดกลุ่มกัน

                    //string subpassword = string_set.ToString();
                    //var new_string = new StringBuilder();
                    int totals = string_set.Length;

                    Random numRnd = new Random();





                    // หา คีย์ในการสุ่ม
                    int Key = numRnd.Next(5, 100);

                    for (int j = 0; j < totals - 1; j++)
                    {

                        // นำ key มาบวกตำแหน่งที่ละตำแหน่งเพื่อหาตำแหน่งที่จะเลื่อนไป หากเกินตำแหน่งสุดท้ายจะกลับ
                        // มายังตำแหน่งแรกแล้วนับต่อไปเรื่อยๆ
                        int next_position = j + Key;


                        // ถ้า next position มีค่ามากกว่าจำนวน char ทั้งหมด ใน string_set
                        if (next_position > totals)
                        {

                            // ให้ทำการลบ กับจำนวนตัวอักษรทั้งหมด ใน string_set หากมีเศษเหลือให้ = ตำแหน่งที่จะย้ายไป
                            int dest_position = next_position - totals;


                            // ตรวจสอบว่าตำแหน่งที่ได้ไม่เกินตำแหน่งที่มีอยู่ใน string_set ถ้าเกินให้ คำนวณต่อ

                            while (dest_position > totals)
                            {
                                dest_position = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dest_position / totals)));
                            }





                            // เก็บค่าตัวอักษรเดิมที่จะถูกแทนที่ไว้ในตัวแปร
                            var old_item = string_set[dest_position];

                            // ย้าย ตัวอักษรตำแหน่งปัจจุบันไปตำแหน่งใหม่
                            string_set[dest_position] = string_set[j];

                            // นำตัวอักษรเดิมก่อนย้ายไปแทนที่ในตำแหน่งปัจจุบัน

                            string_set[j] = old_item;



                        }


                        // ถ้า next position มีค่ามากกว่าจำนวน char ทั้งหมด ใน string_set
                        else if (next_position <= totals)
                        {

                            // ให้ทำการลบ กับจำนวนตัวอักษรทั้งหมด ใน string_set หากมีเศษเหลือให้ = ตำแหน่งที่จะย้ายไป
                            int dest_position2 = totals - next_position;


                            // เก็บค่าตัวอักษรเดิมที่จะถูกแทนที่ไว้ในตัวแปร
                            var old_item = string_set[dest_position2];


                            // ย้าย ตัวอักษรตำแหน่งปัจจุบันไปตำแหน่งใหม่ 
                            string_set[dest_position2] = string_set[j];


                            // นำตัวอักษรเดิมก่อนย้ายไปแทนที่ในตำแหน่งปัจจุบัน

                            string_set[j] = old_item;

                        }

                    }

                }

                return string_set.ToString();

            }
            catch (Exception)
            {
                throw;

            }


        }

        // the second Overload can define Special Charecter together.

        public string New_password(int total, int upper, int lower, int num, int specialcharecter)
        {
            var string_set2 = new StringBuilder(total);
            // create upper case

            if (total > 0)
            {

                if (upper > 0)
                {
                    for (int i = 0; i < upper; i++)
                    {

                        Random Rnd_upper = new Random();

                        int num_upper = Rnd_upper.Next(65, 90);

                        // หน่วงเวลาเพื่อรอ ให้ Process การสุ่มตัวเลขใน step ก่อนหน้าทำเสร็จก่อน
                        Thread.Sleep(20);

                        char chr_upper = (char)num_upper;
                        string_set2.Append(chr_upper);
                    }


                }
                // create lower case

                if (lower > 0)
                {

                    for (int i = 0; i < lower; i++)
                    {
                        Random Rnd_lower = new Random();
                        int num_lower = Rnd_lower.Next(97, 122);

                        // หน่วงเวลาเพื่อรอ ให้ Process การสุ่มตัวเลขใน step ก่อนหน้าทำเสร็จก่อน

                        Thread.Sleep(20);
                        char chr_lower = (char)num_lower;
                        string_set2.Append(chr_lower);




                    }



                }

                // create number 

                if (num > 0)
                {
                    for (int i = 0; i < num; i++)
                    {
                        Random Rnd_upper = new Random();
                        int num_upper = Rnd_upper.Next(0, 9);

                        // หน่วงเวลาเพื่อรอ ให้ Process การสุ่มตัวเลขใน step ก่อนหน้าทำเสร็จก่อน

                        Thread.Sleep(20);
                        string_set2.Append(num_upper.ToString());
                    }
                }


                //create Special charecter 
                if (specialcharecter > 0)
                {
                    char chr_special;
                    bool result = true;


                    for (int i = 0; i < specialcharecter; i++)
                    {
                        Random Rnd_special = new Random();


                        while (result = true)
                        {
                            int num_special = Rnd_special.Next(33, 64);

                            Thread.Sleep(20);

                            if (num_special == 33 || num_special == 42 || num_special == 47 || num_special == 63 || num_special == 64)
                            {

                                chr_special = (char)num_special;
                                string_set2.Append(chr_special);
                                break;


                                //string_set2.Append(num_upper.ToString());
                            }
                            else if (num_special >= 35 && num_special <= 38)
                            {
                                chr_special = (char)num_special;
                                string_set2.Append(chr_special);
                                break;
                            }
                            else
                            {
                                result = false;

                            }




                        }

                    }


                    // sort ให้ข้อมูลไม่จัดกลุ่มกัน

                    //string subpassword = string_set.ToString();
                    //var new_string = new StringBuilder();
                    int totals = string_set2.Length;

                    Random numRnd = new Random();





                    // หา คีย์ในการสุ่ม
                    int Key = numRnd.Next(5, 100);

                    for (int j = 0; j < totals - 1; j++)
                    {

                        // นำ key มาบวกตำแหน่งที่ละตำแหน่งเพื่อหาตำแหน่งที่จะเลื่อนไป หากเกินตำแหน่งสุดท้ายจะกลับ
                        // มายังตำแหน่งแรกแล้วนับต่อไปเรื่อยๆ
                        int next_position = j + Key;


                        // ถ้า next position มีค่ามากกว่าจำนวน char ทั้งหมด ใน string_set
                        if (next_position > totals)
                        {

                            // ให้ทำการลบ กับจำนวนตัวอักษรทั้งหมด ใน string_set หากมีเศษเหลือให้ = ตำแหน่งที่จะย้ายไป
                            int dest_position = next_position - totals;


                            // ตรวจสอบว่าตำแหน่งที่ได้ไม่เกินตำแหน่งที่มีอยู่ใน string_set ถ้าเกินให้ คำนวณต่อ

                            while (dest_position > totals)
                            {
                                dest_position = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dest_position / totals)));
                            }





                            // เก็บค่าตัวอักษรเดิมที่จะถูกแทนที่ไว้ในตัวแปร
                            var old_item = string_set2[dest_position];

                            // ย้าย ตัวอักษรตำแหน่งปัจจุบันไปตำแหน่งใหม่
                            string_set2[dest_position] = string_set2[j];

                            // นำตัวอักษรเดิมก่อนย้ายไปแทนที่ในตำแหน่งปัจจุบัน

                            string_set2[j] = old_item;



                        }


                        // ถ้า next position มีค่ามากกว่าจำนวน char ทั้งหมด ใน string_set
                        else if (next_position <= totals)
                        {

                            // ให้ทำการลบ กับจำนวนตัวอักษรทั้งหมด ใน string_set หากมีเศษเหลือให้ = ตำแหน่งที่จะย้ายไป
                            int dest_position2 = totals - next_position;


                            // เก็บค่าตัวอักษรเดิมที่จะถูกแทนที่ไว้ในตัวแปร
                            var old_item = string_set2[dest_position2];


                            // ย้าย ตัวอักษรตำแหน่งปัจจุบันไปตำแหน่งใหม่ 
                            string_set2[dest_position2] = string_set2[j];


                            // นำตัวอักษรเดิมก่อนย้ายไปแทนที่ในตำแหน่งปัจจุบัน

                            string_set2[j] = old_item;

                        }

                    }



                }


            }

            return string_set2.ToString();

        }

        //ฟังก์ชั่นที่ใช้สำหรับ Validate password โดยมีเงื่อนไขต้องมี อักษรพิมพ์ใหญ่,พิมพ์เล็ก,ตัวเลข,และอักษรพิเศษ อย่างละ 1 ตัว
        public bool Validate_password(string password) // upper ,lower,number,special case อย่างน้อย 1 => ขั้นต่ำ 8 ตัว
        {

            bool final_result = true;
            bool check_upper = true;
            bool check_lower = true;
            bool check_number = true;
            bool check_specialcase = true;


            //var string_buider = new StringBuilder();


            for (int i = 0; i < password.Length; i++)
            {
                int char_item = (int)(password[i]);


                // check upper
                if (char_item >= 65 && char_item <= 90)
                {
                    check_upper = true;
                    break;
                }
                else
                {
                    check_upper = false;
                }
            }


            //check lower

            for (int j = 0; j < password.Length; j++)
            {

                int char_item = (int)(password[j]);

                if (char_item >= 97 && char_item <= 122)
                {
                    check_lower = true;
                    break;
                }
                else
                {
                    check_lower = false;
                }
            }
            // check number 

            for (int k = 0; k < password.Length; k++)
            {
                int char_item = (int)(password[k]);


                if (char_item >= 48 && char_item <= 57)
                {
                    check_number = true;
                    break;
                }
                else
                {
                    check_number = false;
                }
            }
            //check special case

            for (int m = 0; m < password.Length; m++)
            {

                int char_item = (int)(password[m]);

                if (char_item >= 35 && char_item <= 38 || char_item >= 63 && char_item <= 64)
                {
                    check_specialcase = true;
                    break;
                }
                else if (char_item == 33 || char_item == 42 || char_item == 47)
                {
                    check_specialcase = true;
                    break;
                }
                else
                {
                    check_specialcase = false;
                }



            }





            // summary 
            if (check_upper == true && check_lower == true && check_number == true && check_specialcase == true)
            {
                final_result = true;
            }
            else
            {
                final_result = false;
            }

            return final_result;


        }


        // เข้ารหัส


        //มี Overload 2 ตัว 
        //Overload ที่1 ใช้สำหรับนำ Password ที่ตั้งไว้ มาเข้ารหัส Hash function โดยจะมีการ Generate Salt คีย์โดยอัติโนมัติ

        public string Hash_function(string original_password)
        {
            string Hashedpassword;

            var new_salt = GenerateSalt();


            Hashedpassword = computeHash(Encoding.UTF8.GetBytes(original_password), Encoding.UTF8.GetBytes(new_salt));


            return Hashedpassword;
        }


        //Overload ที่2 ใช้สำหรับนำ Password ที่ตั้งไว้ มาเข้ารหัส Hash function โดยสามารถใส่ Key Salt ที่ Generate ต่างหากไว้มาใช้เป็น Parameter
        public string Hash_function(string original_password, string Result_key)
        {
            string Hashedpassword;



            Hashedpassword = computeHash(Encoding.UTF8.GetBytes(original_password), Encoding.UTF8.GetBytes(Result_key));


            return Hashedpassword;
        }

        // generate key Salt คือ เลขรันที่ถูก Random ขึ้นมาเพื่อเอามาคำนวณรวมกับ Hash Function ทำให้ Password เกิดความปลอดภัยมากขึ้น
        public string GenerateSalt()
        {
            var bytes = new byte[128 / 8];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }


        // เป็นฟังก์ชั่นที่จะนำ Password   และ Salt มาแปลงเป็น binary และ ใส่เข้าไปใน Hash function และ Return ออกมาเป็น Password ที่เข้ารหัสที่ปลอดภัยมากขึ้น
        public string computeHash(byte[] bytetoHash, byte[] salt)
        {
            var byteresult = new Rfc2898DeriveBytes(bytetoHash, salt, 1000);
            return Convert.ToBase64String(byteresult.GetBytes(24));
        }



    }

    }
