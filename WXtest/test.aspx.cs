using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WXtest
{
    public partial class test : System.Web.UI.Page
    {
        string aeskey = "";
        string content = string.Empty;
        string Encrycontent = "";
        string q1_1 = "";
        string q1_2 = "";
        string q2 = "";
        string q3 = "";
        string q4 = "";
        string q5 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            content = Request.Form["content"];
            aeskey = "444e83d37aef4ac5ba316223429f38da";
            this.DataS.InnerText =  DateTime.Now.ToShortDateString();
            string getV = Receive(aeskey, content);

            //getV = "{\"answer\":{\"activity\":\"113424987\",\"name\":\"员工健康自主检查问卷 // แบบสำรวจรายงานสุขภาพของพนักงาน // Employee health self-inspection questionnaire\",\"ipaddress\":\"183.63.204.167\",\"source\":\"directphone\",\"q1_1\":\"16097\",\"q1_2\":\"123\",\"q1_3\":\"123\",\"q1_4\":\"123\",\"q2\":\"1\",\"q3\":\"2\",\"q4\":\"1\",\"q5\":\"2\",\"province\":\"广东\",\"city\":\"东莞\",\"index\":\"9033\",\"joinid\":\"109125832629\",\"timetaken\":\"34\",\"submittime\":\"2021 - 04 - 21 17:25:20\",\"sign\":\"1bdbae8bf78becc6f8942cfa067f666c6bb313dd\"}}";

            if (getV.Contains("读取内容为空"))
            {
                return;
            }

            //解析失败的默认返回值

            JObject jo = JObject.Parse(getV);//或者JObject jo = JObject.Parse(jsonText);
                                                 // answer answers = new answer();
            JObject answers = JObject.Parse(jo["answer"].ToString());

            q1_1 = answers["q1_1"].ToString();//工号
            q1_2 = answers["q1_2"].ToString();//姓名
            q2 = answers["q2"].ToString();//接触新冠病毒 1 是
            q3 = answers["q3"].ToString();//咳嗽 1 是
            q4 = answers["q4"].ToString();//体温状况 是
            q5 = answers["q5"].ToString();//是否去过高风险地区 是

            this.EmpNo.InnerText =  q1_1;
            //this.Names.InnerText = "  Name :";
            this.NameV.InnerText =  q1_2;

            if (q2 == "2" && q3 == "2" && q4 == "1" && q5 == "2")
            {
                // this.Image1.ImageUrl = "~/20210421175851.png";//绿色通过
                this.PassNo.InnerText = "Pass (ผ่าน)";
                //this.PassNo.Attributes.Add("color", "orangered");
                //this.PassNo.Style["color"] = "#fb895e";
                this.PassNo.Style["color"] = "White"; //;System.Drawing.Color.White;
                this.main.Style["background"] = "ForestGreen";
            }
            else
            {
                //this.Image1.ImageUrl = "~/20210421175833.png";//红色 失败不能通过
                this.PassNo.InnerText = "Not Pass (ไม่ผ่าน)";
                this.PassNo.Style["color"] = "#fb895e";
                this.main.Style["background"] = "#e62e2d";
                this.Tips.InnerText = "**-如生病或感覺不舒服,請在家休息,找醫生及聯繫組長"+ "\r\n\n" +
                                      "หากท่านรู้สึกไม่สบายให้พักผ่อนที่บ้าน ติดต่อหัวหน้าและรีบพบแพทย์ทันที" + "\r\n\n" +
                                      "-請認真填寫,檢查每項是否正確" + "\r\n\n" +
                                      "ตรวจสอบข้อมูลให้ถูกต้องก่อนส่งทุกครั้ง";
            }
        }

        //接收推送消息
        protected string Receive(string aeskey, string content)
        {
            try
            {
                if (!string.IsNullOrEmpty(content) && !string.IsNullOrEmpty(aeskey))
                {
                    content = Decrypt(aeskey, content);
                    return content;
                }
                return "读取内容为空";
            }
            catch (Exception e)
            {
                return "出错啦！\r\n" + e.Message;
            }
        }

        public string Decrypt(string aeskey, string encrypted)
        {

            try
            {
                //1）读取推送的BASE64数据为byte[] encryptedData;
                byte[] encryptedData = Convert.FromBase64String(encrypted);
                if (encryptedData == null || encryptedData.Length < 17)
                    return "";
                //2）取AES加解密密钥作为AES解密的KEY;
                byte[] key = Encoding.UTF8.GetBytes(aeskey);
                //3) 取byte[] encryptedData的前16位做为IV；
                byte[] iv = encryptedData.Take(16).ToArray();
                //4）取第16位后的字节数组做为待解密内容；
                encryptedData = encryptedData.Skip(16).ToArray();
                using (var aes = new RijndaelManaged())
                {
                    //5）解密模式使用CBC（密码块链模式）；
                    aes.Mode = CipherMode.CBC;
                    //6）填充模式使用PKCS #7（填充字符串由一个字节序列组成，每个字节填充该字节序列的长度）；
                    aes.Padding = PaddingMode.PKCS7;
                    aes.Key = key;
                    aes.IV = iv;
                    var cryptoTransform = aes.CreateDecryptor();
                    //7）使用配置好的实例化AES对象执行解密
                    byte[] r = cryptoTransform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
                    //8）使用UTF-8的方式，读取二进制数组得到原始数据
                    Encrycontent = Encoding.UTF8.GetString(r);
                    //return Encoding.UTF8.GetString(r);
                }


                return Encrycontent;


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}