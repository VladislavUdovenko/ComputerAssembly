using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerAssembly
{
    public partial class FormOrders : Form
    {
        public FormOrders()
        {
            BackColor = Color.FromArgb(34, 33, 74);
            InitializeComponent();


            var tableAssembledConfigurations = new TableLayoutPanel();
            tableAssembledConfigurations.Dock = DockStyle.Fill;

            #region Adding rows and columns to the table assembled configurations
            tableAssembledConfigurations.RowStyles.Add(new RowStyle(SizeType.Absolute, 55));
            tableAssembledConfigurations.RowStyles.Add(new RowStyle(SizeType.Absolute, 300));
            tableAssembledConfigurations.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            for (int i = 0; i < 4; i++)
                tableAssembledConfigurations.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));

            # region Buttons for naming configurations
            var configurationName1 = CreateButton("Для домашнего использования");
            var configurationName2 = CreateButton("Недорогой игровой компьютер");
            var configurationName3 = CreateButton("Дорогой игровой компьютер");
            var configurationName4 = CreateButton("Компьютер для видеомонтажа");

            #endregion

            #region Pictureboxes for configuration images
            var configurationImage1 = CreateConfigurationImage(Properties.Resources.domashniy, new Padding(100, 0, 0, 0));
            var configurationImage2 = CreateConfigurationImage(Properties.Resources.nedorogoyIgr, new Padding(100, 0, 0, 0));
            var configurationImage3 = CreateConfigurationImage(Properties.Resources.dorogoyIgr, new Padding(90, 0, 0, 0));
            var configurationImage4 = CreateConfigurationImage(Properties.Resources.videomont, new Padding(90, 0, 0, 0));
            #endregion

            #region
            var computerDescriptionButton1 = CreateButton("Процессор Intel Core i5-10600 OEM\n\n" +
                                                         "Материнская плата MSI B460M - A PRO\n\n" +
                                                         "Кулер для процессора DEEPCOOL GAMMAXX 300[DP - MCH3 - GMX300]\n\n" +
                                                         "Оперативная память Goodram IRDM X IR - X2666D464L16S / 8G\n\n" +
                                                         "120 ГБ SSD - накопитель GIGABYTE[GP - GSTFS31120GNTD]\n\n" +
                                                         "Блок питания Corsair CV550[CP - 9020210 - EU]\n\n" +
                                                         "41к");
            var computerDescriptionButton2 = CreateButton("Процессор AMD Ryzen 5 3600X OEM\n\n" +
                                                          "Материнская плата GIGABYTE B550M DS3H\n\n" +
                                                          "Видеокарта Palit GeForce GTX 1660 SUPER Gaming Pro[NE6166S018J9 - 1160A - 1]\n\n" +
                                                          "Кулер для процессора AeroCool Verkho 4 Dark\n\n" +
                                                          "Оперативная память Goodram Iridium[IR - XW3000D464L16S / 16GDC] 16 ГБ\n\n" +
                                                          "240 ГБ SSD - накопитель Crucial BX500[CT240BX500SSD1]\n" +
                                                          "1 ТБ Жесткий диск WD Blue[WD10EZRZ]\n" +
                                                          "Блок питания Chieftec 500W[APB - 500B8]\n\n" +
                                                          "68к");
            var computerDescriptionButton3 = CreateButton("Процессор i5 - 10600KF OEM\n\n" +
                                                          "Материнская плата MSI Z490 - A PRO\n\n" +
                                                          "Видеокарта Palit GeForce RTX 3060 DUAL OC [NE63060T19K9-190AD]\n\n" +
                                                          "Кулер для процессора DEEPCOOL GAMMAXX 400 EX\n\n" +
                                                          "Оперативная память 16Гб Goodram Iridium IR - X2666D464L16S / 16G\n\n" +
                                                          "SSD Smartbuy Jolt[SB240GB - JLT - 25SAT3]\n\n" +
                                                          "500ГБ M.2 WD Blue SN550[WDS500G2B0C]\n\n" +
                                                          "Блок питания Aerocool KCAS PLUS 700W[KCAS - 700 PLUS]\n\n" +
                                                          "103к");
            var computerDescriptionButton4 = CreateButton("Процессор i9 - 10900F 2.8 - 5.2GHz 10 Core 20 Threads\n\n" +
                                                          "Материнская плата Z490 - P S1200 ASUS PRIME ATX\n\n" +
                                                          "Видеокарта  Radeon  PRO W5500 8GB\n\n" +
                                                          "Кулер для процессора ID - COOLING SE - 207BK TDP 250W / PWM\n\n" +
                                                          "Оперативная память 32Gb DDR4 2666MHz\n\n" +
                                                          "SSD 250Gb PCI - E 4x\n\n" +
                                                          "2 Tb(7200rpm) 64Mb\n\n" +
                                                          "Блок питания 700W\n\n" +
                                                          "140к");
            #endregion Controls

            tableAssembledConfigurations.Controls.Add(configurationName1, 0, 0);
            tableAssembledConfigurations.Controls.Add(configurationName2, 1, 0);
            tableAssembledConfigurations.Controls.Add(configurationName3, 2, 0);
            tableAssembledConfigurations.Controls.Add(configurationName4, 3, 0);

            tableAssembledConfigurations.Controls.Add(configurationImage1, 0, 1);
            tableAssembledConfigurations.Controls.Add(configurationImage2, 1, 1);
            tableAssembledConfigurations.Controls.Add(configurationImage3, 2, 1);
            tableAssembledConfigurations.Controls.Add(configurationImage4, 3, 1);

            tableAssembledConfigurations.Controls.Add(computerDescriptionButton1, 0, 2);
            tableAssembledConfigurations.Controls.Add(computerDescriptionButton2, 1, 2);
            tableAssembledConfigurations.Controls.Add(computerDescriptionButton3, 2, 2);
            tableAssembledConfigurations.Controls.Add(computerDescriptionButton4, 3, 2);

            Controls.Add(tableAssembledConfigurations);
            #endregion
        }

        public Button CreateButton(string text)
        {
            var button = new Button();
            button.FlatStyle = FlatStyle.Flat;
            button.Dock = DockStyle.Fill;
            button.Font = new Font("Microsoft Sans Serif", 10F);
            button.ForeColor = SystemColors.Highlight;
            button.Text = text;

            return button;
        }

        public PictureBox CreateConfigurationImage(Image image, Padding padding)
        {
            var pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.Location = new Point(13, 64);
            pictureBox.Padding = padding;
            pictureBox.Size = new Size(256, 284);
            pictureBox.Dock = DockStyle.Fill;
            return pictureBox;
        }
    }
}
