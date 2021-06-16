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
    public partial class FormСonfigurator : Form
    {
        public Panel BasketPanel { get; set; }
        private Button BtnBasketHeader { get; set; }

        private Button BtnCPUInBasket { get; set; }
        private Button BtnMotherboardInBasket { get; set; }
        private Button BtnVideoCardInBasket { get; set; }
        private Button BtnCoolingInBasket { get; set; }
        private Button BtnOperatingFeeInBasket { get; set; }
        private Button BtnDataStoreInBasket { get; set; }
        private Button BtnSSDInBasket { get; set; }
        private Button BtnPowerSupplyInBasket { get; set; }
        private Button BtnTotalPriceInBasket { get; set; }
        public FormСonfigurator()
        {
            BackColor = Color.FromArgb(34, 33, 74);
            InitializeComponent();

            var componentTable = new TableLayoutPanel();
            componentTable.Dock = DockStyle.Fill;

            var basketTable = new TableLayoutPanel();
            basketTable.Dock = DockStyle.Fill;

            #region Adding rows and columns to the components table
            componentTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
            componentTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            for (int i = 0; i < 8; i++)
                componentTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.285f));
            #endregion

            #region Adding rows and columns to the basket table
            basketTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
            for (int i = 0; i < 8; i++)
                basketTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
            basketTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            basketTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));

            basketTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            #endregion

            #region Creating panels
            // Для конструктора
            var panelCPU = CreatePanel(DockStyle.Fill);
            var panelMotherboard = CreatePanel(DockStyle.Fill);
            var panelVideoCard = CreatePanel(DockStyle.Fill);
            var panelCooling = CreatePanel(DockStyle.Fill);
            var panelOperatingFee = CreatePanel(DockStyle.Fill);
            var panelDataStore = CreatePanel(DockStyle.Fill);
            var panelSSD = CreatePanel(DockStyle.Fill);
            var panelPowerSupply = CreatePanel(DockStyle.Fill);

            //Для панели корзины
            BasketPanel = CreatePanel(DockStyle.Left);
            BasketPanel.Size = new Size(210, 1);
            #endregion

            #region Creating buttons 
            // Для конструктора
            var btnCPU = CreateButton(SystemColors.Highlight, DockStyle.Top, "Процессор",
                (sender, args) => ShowPanel(panelCPU, componentTable), basketTable);
            var btnMotherboard = CreateButton(SystemColors.Highlight, DockStyle.Top, "Материнская плата",
                (sender, args) => ShowPanel(panelMotherboard, componentTable), basketTable);
            var btnVideoCard = CreateButton(SystemColors.Highlight, DockStyle.Top, "Видеокарта",
                (sender, args) => ShowPanel(panelVideoCard, componentTable), basketTable);
            var btnCooling = CreateButton(SystemColors.Highlight, DockStyle.Top, "Охлаждение",
                (sender, args) => ShowPanel(panelCooling, componentTable), basketTable);
            var btnOperatingFee = CreateButton(SystemColors.Highlight, DockStyle.Top, "Оперативная память",
               (sender, args) => ShowPanel(panelOperatingFee, componentTable), basketTable);
            var btnDataStore = CreateButton(SystemColors.Highlight, DockStyle.Top, "Накопитель для дополнительных файлов",
               (sender, args) => ShowPanel(panelDataStore, componentTable), basketTable);
            var btnSSD = CreateButton(SystemColors.Highlight, DockStyle.Top, "Накопитель для системы",
               (sender, args) => ShowPanel(panelSSD, componentTable), basketTable);
            var btnPowerSupply = CreateButton(SystemColors.Highlight, DockStyle.Top, "Блок питания",
                (sender, args) => ShowPanel(panelPowerSupply, componentTable), basketTable);

            // Для панели корзины
            BtnBasketHeader = CreateButton(Color.FromArgb(253, 138, 114), DockStyle.Top, "Текущая сборка",
                (sender, args) => { }, basketTable);
            BtnCPUInBasket = CreateButton(SystemColors.Highlight, DockStyle.Top, "Процессор \n 0 рублей",
                (sender, args) => { BtnCPUInBasket.Text = "Процессор \n 0 рублей"; RecalculateTotalCost(); }, basketTable);
            BtnMotherboardInBasket = CreateButton(SystemColors.Highlight, DockStyle.Top, "Материнская плата \n 0 рублей",
                (sender, args) => { BtnMotherboardInBasket.Text = "Материнская плата \n 0 рублей"; RecalculateTotalCost(); }, basketTable);
            BtnVideoCardInBasket = CreateButton(SystemColors.Highlight, DockStyle.Top, "Видеокарта \n 0 рублей",
                (sender, args) => { BtnVideoCardInBasket.Text = "Видеокарта \n 0 рублей"; RecalculateTotalCost(); }, basketTable);
            BtnCoolingInBasket = CreateButton(SystemColors.Highlight, DockStyle.Top, "Охлаждение \n 0 рублей",
               (sender, args) => { BtnCoolingInBasket.Text = "Охлаждение \n 0 рублей"; RecalculateTotalCost(); }, basketTable);
            BtnOperatingFeeInBasket = CreateButton(SystemColors.Highlight, DockStyle.Top, "ОЗУ \n 0 рублей",
               (sender, args) => { BtnOperatingFeeInBasket.Text = "ОЗУ \n 0 рублей"; RecalculateTotalCost(); }, basketTable);
            BtnSSDInBasket = CreateButton(SystemColors.Highlight, DockStyle.Top, "Накопитель для системы \n 0 рублей",
               (sender, args) => { BtnSSDInBasket.Text = "Накопитель для системы \n 0 рублей"; RecalculateTotalCost(); }, basketTable);
            BtnDataStoreInBasket = CreateButton(SystemColors.Highlight, DockStyle.Top, "Накопитель для доп. файлов \n 0 рублей",
               (sender, args) => { BtnDataStoreInBasket.Text = "Накопитель для доп. файлов \n 0 рублей"; RecalculateTotalCost(); }, basketTable);
            BtnPowerSupplyInBasket = CreateButton(SystemColors.Highlight, DockStyle.Top, "Блок питания \n 0 рублей",
               (sender, args) => { BtnPowerSupplyInBasket.Text = "Блок питания \n 0 рублей"; RecalculateTotalCost(); }, basketTable);
            BtnTotalPriceInBasket = CreateButton(Color.FromArgb(253, 138, 114), DockStyle.Top, "Итоговая стоимость: \n 0 рублей",
               (sender, args) => { BtnTotalPriceInBasket.Text = "Итоговая стоимость: \n 0 рублей"; RecalculateTotalCost(); }, basketTable);

            // Кнопки для выбора процессоров:
            var btnCPU1 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "i3-10100F OEM \n 9000 рублей", BtnCPUInBasket, basketTable);
            var btnCPU2 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "i3 10100 OEM \n 13000 рублей", BtnCPUInBasket, basketTable);
            var btnCPU3 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "i5-10400F OEM \n 13000 рублей", BtnCPUInBasket, basketTable);
            var btnCPU4 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "i5-10600KF OEM \n 16000 рублей", BtnCPUInBasket, basketTable);
            var btnCPU5 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "i5-10600 OEM OEM \n 18000 рублей", BtnCPUInBasket, basketTable);
            var btnCPU6 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "i5-10600K OEM \n 18000 рублей", BtnCPUInBasket, basketTable);
            var btnCPU7 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "i7-10700F OEM \n 24000 рублей", BtnCPUInBasket, basketTable);
            var btnCPU8 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "i7-10700 OEM \n 26000 рублей", BtnCPUInBasket, basketTable);
            var btnCPU9 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "i7-10700KF OEM \n 27000 рублей", BtnCPUInBasket, basketTable);
            var btnCPU10 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "i7-10700K OEM \n 29000 рублей", BtnCPUInBasket, basketTable);

            // Кнопки для выбора материнских плат:
            var btnMotherboard1 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "ASRock B460 Phantom Gaming 4 \n 8000 рублей", BtnMotherboardInBasket, basketTable);
            var btnMotherboard2 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "ASUS PRIME B460-PLUS \n 10000 рублей", BtnMotherboardInBasket, basketTable);
            var btnMotherboard3 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "MSI Z490-A PRO \n 12500 рублей", BtnMotherboardInBasket, basketTable);

            // Кнопки для выбора видеокарт:
            var btnVideoCard1 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "GTX 1060 \n 15000 рублей", BtnVideoCardInBasket, basketTable);
            var btnVideoCard2 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "GTX 1660 \n 20000 рублей", BtnVideoCardInBasket, basketTable);
            var btnVideoCard3 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "RTX 2060 \n 30000 рублей", BtnVideoCardInBasket, basketTable);
            var btnVideoCard4 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "RTX 3060 \n 50000 рублей", BtnVideoCardInBasket, basketTable);
            var btnVideoCard5 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "RTX 3080 \n 75000 рублей", BtnVideoCardInBasket, basketTable);

            // Кнопки для выбора охлаждения:
            var btnCooling1 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "ID-Cooling SE-902-SD \n 1000 рублей", BtnCoolingInBasket, basketTable);
            var btnCooling2 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "DEEPCOOL GAMMAXX 400 EX \n 3000 рублей", BtnCoolingInBasket, basketTable);
            var btnCooling3 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "Cougar Aqua 280 \n 7000 рублей", BtnCoolingInBasket, basketTable);

            // Кнопки для выбора ОЗУ:
            var btnOperatingFee1 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "1x4gb: Goodram Iridium IR-X3000D464L16S/4G\n 2000 рублей", BtnOperatingFeeInBasket, basketTable);
            var btnOperatingFee2 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "2x4gb: Goodram IRDM X IR-X2666D464L16S/8G\n 4000 рублей", BtnOperatingFeeInBasket, basketTable);
            var btnOperatingFee3 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "2x8gb: Goodram Iridium IR-X2666D464L16S/16G\n 7000 рублей", BtnOperatingFeeInBasket, basketTable);

            // Кнопки для выбора хранилища данных:
            var btnDataStore1 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "1ТБ HDD WD Blue [WD10EZEX]\n 3000 рублей", BtnDataStoreInBasket, basketTable);
            var btnDataStore2 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "500ГБ M.2 WD Blue SN550 [WDS500G2B0C]\n 7000 рублей", BtnDataStoreInBasket, basketTable);

            // Кнопки для выбора SSD:
            var btnSSD1 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "SSD Smartbuy Jolt [SB240GB-JLT-25SAT3]\n 3000 рублей", BtnSSDInBasket, basketTable);

            // Кнопки для выбора блоков питания:
            var btnPowerSupply1 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "Aerocool VX PLUS 400W [VX-400 PLUS]\n 2000 рублей", BtnPowerSupplyInBasket, basketTable);
            var btnPowerSupply2 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "Aerocool VX PLUS 500W [VX-500 PLUS RGB]\n 2500 рублей", BtnPowerSupplyInBasket, basketTable);
            var btnPowerSupply3 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "Cougar XTC ARGB 600 [CGR XG-600]\n 4000 рублей", BtnPowerSupplyInBasket, basketTable);
            var btnPowerSupply4 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "Aerocool KCAS PLUS 700W [KCAS-700 PLUS]\n 4750 рублей", BtnPowerSupplyInBasket, basketTable);
            var btnPowerSupply5 = CreateComponentButton(SystemColors.Highlight, DockStyle.Top,
                "Aerocool KCAS PLUS 800W [KCAS-800 PLUS]\n 5200 рублей", BtnPowerSupplyInBasket, basketTable);
            #endregion


            #region Adding controls to the components table

            componentTable.Controls.Add(btnCPU, 0, 0);
            componentTable.Controls.Add(btnMotherboard, 1, 0);
            componentTable.Controls.Add(btnVideoCard, 2, 0);
            componentTable.Controls.Add(btnCooling, 3, 0);
            componentTable.Controls.Add(btnOperatingFee, 4, 0);
            componentTable.Controls.Add(btnSSD, 5, 0);
            componentTable.Controls.Add(btnDataStore, 6, 0);
            componentTable.Controls.Add(btnPowerSupply, 7, 0);

            componentTable.Controls.Add(panelCPU, 0, 1);
            componentTable.Controls.Add(panelMotherboard, 1, 1);
            componentTable.Controls.Add(panelVideoCard, 2, 1);
            componentTable.Controls.Add(panelCooling, 3, 1);
            componentTable.Controls.Add(panelOperatingFee, 4, 1);
            componentTable.Controls.Add(panelSSD, 5, 1);
            componentTable.Controls.Add(panelDataStore, 6, 1);
            componentTable.Controls.Add(panelPowerSupply, 7, 1);

            #endregion

            #region Adding controls to the basket table
            basketTable.Controls.Add(BtnBasketHeader, 0, 0);
            basketTable.Controls.Add(BtnCPUInBasket, 0, 1);
            basketTable.Controls.Add(BtnMotherboardInBasket, 0, 2);
            basketTable.Controls.Add(BtnVideoCardInBasket, 0, 3);
            basketTable.Controls.Add(BtnCoolingInBasket, 0, 4);
            basketTable.Controls.Add(BtnOperatingFeeInBasket, 0, 5);
            basketTable.Controls.Add(BtnSSDInBasket, 0, 6);
            basketTable.Controls.Add(BtnDataStoreInBasket, 0, 7);
            basketTable.Controls.Add(BtnPowerSupplyInBasket, 0, 8);
            basketTable.Controls.Add(new Panel(), 0, 9);
            basketTable.Controls.Add(BtnTotalPriceInBasket, 0, 10);
            #endregion

            #region Controls          
            // Контролы панели процессоров
            panelCPU.Controls.Add(btnCPU10);
            panelCPU.Controls.Add(btnCPU9);
            panelCPU.Controls.Add(btnCPU8);
            panelCPU.Controls.Add(btnCPU7);
            panelCPU.Controls.Add(btnCPU6);
            panelCPU.Controls.Add(btnCPU5);
            panelCPU.Controls.Add(btnCPU4);
            panelCPU.Controls.Add(btnCPU3);
            panelCPU.Controls.Add(btnCPU2);
            panelCPU.Controls.Add(btnCPU1);

            // Контролы панели материнских плат
            panelMotherboard.Controls.Add(btnMotherboard3);
            panelMotherboard.Controls.Add(btnMotherboard2);
            panelMotherboard.Controls.Add(btnMotherboard1);

            // Контролы панели видеокарты
            panelVideoCard.Controls.Add(btnVideoCard5);
            panelVideoCard.Controls.Add(btnVideoCard4);
            panelVideoCard.Controls.Add(btnVideoCard3);
            panelVideoCard.Controls.Add(btnVideoCard2);
            panelVideoCard.Controls.Add(btnVideoCard1);

            // Контролы панели охлаждения
            panelCooling.Controls.Add(btnCooling3);
            panelCooling.Controls.Add(btnCooling2);
            panelCooling.Controls.Add(btnCooling1);

            // Контролы панели ОЗУ
            panelOperatingFee.Controls.Add(btnOperatingFee3);
            panelOperatingFee.Controls.Add(btnOperatingFee2);
            panelOperatingFee.Controls.Add(btnOperatingFee1);

            // Контролы панели хранилища данных
            panelDataStore.Controls.Add(btnDataStore2);
            panelDataStore.Controls.Add(btnDataStore1);

            // Контролы SSD
            panelSSD.Controls.Add(btnSSD1);

            // Контролы панели блоков питания
            panelPowerSupply.Controls.Add(btnPowerSupply5);
            panelPowerSupply.Controls.Add(btnPowerSupply4);
            panelPowerSupply.Controls.Add(btnPowerSupply3);
            panelPowerSupply.Controls.Add(btnPowerSupply2);
            panelPowerSupply.Controls.Add(btnPowerSupply1);

            BasketPanel.Controls.Add(basketTable);

            Controls.Add(componentTable);
            Controls.Add(BasketPanel);
            #endregion
        }

        private void AddComponentToBasket(Button componentToBeChanged, Button componentToBeAdded)
        {
            componentToBeChanged.Text = componentToBeAdded.Text;
        }

        private Button CreateComponentButton(Color color, DockStyle dockStyle, string text, Button componentToBeChanged, TableLayoutPanel basketTable)
        {
            var componentToBeAdded = CreateButton(color, dockStyle, text, (sender, args) => { }, basketTable);
            componentToBeAdded.Click += (sender, args) => AddComponentToBasket(componentToBeChanged, componentToBeAdded);
            componentToBeAdded.Click += (sender, args) => RecalculateTotalCost();
            return componentToBeAdded;
        }

        private void RecalculateTotalCost()
        {
            var totalPrice = 0;

            totalPrice += GetPrice(BtnCPUInBasket);
            totalPrice += GetPrice(BtnMotherboardInBasket);
            totalPrice += GetPrice(BtnVideoCardInBasket);
            totalPrice += GetPrice(BtnCoolingInBasket);
            totalPrice += GetPrice(BtnOperatingFeeInBasket);
            totalPrice += GetPrice(BtnSSDInBasket);
            totalPrice += GetPrice(BtnDataStoreInBasket);
            totalPrice += GetPrice(BtnPowerSupplyInBasket);

            BtnTotalPriceInBasket.Text = String.Format("Итоговая стоимость: \n {0} рублей", totalPrice.ToString());
        }

        private int GetPrice(Button button)
        {
            var words = button.Text.Split(' ');
            return int.Parse(words[words.Length - 2]);
        }

        private Button CreateButton(Color color, DockStyle dockStyle, string text, EventHandler eventHandler, TableLayoutPanel basketTable)
        {
            var button = new Button();
            button.FlatStyle = FlatStyle.Flat;
            button.ForeColor = color;
            button.Dock = dockStyle;
            button.Size = new Size(1, 70);
            button.Text = text;
            button.UseVisualStyleBackColor = true;
            button.Font = new Font("Microsoft Sans Serif", 8);

            button.Click += eventHandler;
            return button;
        }

        private Panel CreatePanel(DockStyle dockStyle)
        {
            var panel = new Panel()
            {
                Dock = dockStyle,
                BackColor = Color.FromArgb(26, 25, 62),
                Visible = false
            };
            return panel;
        }

        public void HidePanel(TableLayoutPanel table)
        {
            foreach (var control in table.Controls)
            {
                if (control is Panel)
                {
                    var panel = control as Panel;
                    panel.Visible = false;
                }
            }
        }

        public void HidePanel(Panel panel)
        {
            panel.Visible = false;
        }

        public void ShowPanel(Panel panel, TableLayoutPanel table)
        {
            if (!panel.Visible)
            {
                HidePanel(table);
                panel.Visible = true;
            }
            else
                panel.Visible = false;
        }

        public void ShowPanel(Panel panel)
        {
            if (panel.Visible)
                panel.Visible = false;
            else
                panel.Visible = true;
        }
    }
}
