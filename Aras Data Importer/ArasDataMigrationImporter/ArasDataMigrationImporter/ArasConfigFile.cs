using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Aras.IOM;

namespace ArasDataMigrationImporter
{
    public partial class ArasConfigFile : Form
    {
        static Innovator inn = null;

        public ArasConfigFile()
        {
            InitializeComponent();
        }
        public ArasConfigFile(HttpServerConnection conn)
        {
            InitializeComponent();
            inn = IomFactory.CreateInnovator(conn);
            ///parent = (Form1)this.Owner;
        }

        private void Config_Load(object sender, EventArgs e)
        {
            updateDefaultValuesOnForm();
            loadParentItemList();
        }

        private void updateDefaultValuesOnForm()
        {
            String aConfigPath = System.Windows.Forms.Application.ExecutablePath + ".config";


            //update Parent Item
            string parentItemConfigValue = ConfigurationManager.AppSettings["ParentType"]; //xmlNode.SelectSingleNode("//aras[@key='ParentType']").Attributes["value"].Value;

            parentItemTypeCBox.Text = parentItemConfigValue;



            childItemTypeCBox.Text = ConfigurationManager.AppSettings["ChildType"]; //xmlNode.SelectSingleNode("//aras[@key='ChildType']").Attributes["value"].Value;
            parentStuctRelCBox.Text = ConfigurationManager.AppSettings["ParentStructure"]; //xmlNode.SelectSingleNode("//aras[@key='ParentStructure']").Attributes["value"].Value;
            childStuctRelCBox.Text = ConfigurationManager.AppSettings["ChildStructure"]; //xmlNode.SelectSingleNode("//aras[@key='ChildStructure']").Attributes["value"].Value;
            parentChildRelCBox.Text = ConfigurationManager.AppSettings["ParentChildRelation"]; //xmlNode.SelectSingleNode("//aras[@key='ParentChildRelation']").Attributes["value"].Value;
            parentFileRelCBox.Text = ConfigurationManager.AppSettings["ParentFileRelation"]; //xmlNode.SelectSingleNode("//aras[@key='ParentFileRelation']").Attributes["value"].Value;
            childFileRelCBox.Text = ConfigurationManager.AppSettings["ChildFileRelation"]; //xmlNode.SelectSingleNode("//aras[@key='ChildFileRelation']").Attributes["value"].Value;
            fileFolderTBox.Text = ConfigurationManager.AppSettings["FilesFolder"]; //xmlNode.SelectSingleNode("//aras[@key='FilesFolder']").Attributes["value"].Value;
            delimiterTBox.Text = ConfigurationManager.AppSettings["delimiter"]; //xmlNode.SelectSingleNode("//aras[@key='delimiter']").Attributes["value"].Value;
            deleteFilesOnRevCBox.Text = ConfigurationManager.AppSettings["Delete_Files_OnRevise"]; //xmlNode.SelectSingleNode("//aras[@key='Delete_Files_OnRevise']").Attributes["value"].Value;
            dateFormatTBox.Text = ConfigurationManager.AppSettings["date_format"]; //xmlNode.SelectSingleNode("//aras[@key='date_format']").Attributes["value"].Value;



        }

        private Item GetItemType(String ItemType)
        {
            Item result = inn.newItem();
            String AMLStr = "<AML>" +
                  "<Item type='ItemType' action='get' where=\"[ItemType].name='" + ItemType + "'\" select='*'>" +
                    "<Relationships>" +
                      "<Item type='Property' action='get' select='name,data_type,data_source'>" +
                      "</Item>" +
                      "<Item type='RelationshipType' action='get' select='*'>" +
                        "<related_id>" +
                          "<Item type='ItemType' action='get' select='*'>" +
                            "<Relationships>" +
                              "<Item type='Property' action='get' select='name,data_type,data_source'>" +
                              "</Item>" +
                            "</Relationships>" +
                          "</Item>" +
                        "</related_id>" +
                      "</Item>" +
                    "</Relationships>" +
                  "</Item>" +
                "</AML>";

            result = inn.applyAML(AMLStr);

            return result;
        }

        private Item GetAllItemType()
        {
            Item result = inn.newItem();
            String AMLStr = "<AML>" +
                  "<Item type='ItemType' action='get' select='*'>" +
                    "<Relationships>" +
                      "<Item type='Property' action='get' select='name,data_type,data_source'>" +
                      "</Item>" +
                      "<Item type='RelationshipType' action='get' select='*'>" +
                        "<related_id>" +
                          "<Item type='ItemType' action='get' select='*'>" +
                            "<Relationships>" +
                              "<Item type='Property' action='get' select='name,data_type,data_source'>" +
                              "</Item>" +
                            "</Relationships>" +
                          "</Item>" +
                        "</related_id>" +
                      "</Item>" +
                    "</Relationships>" +
                  "</Item>" +
                "</AML>";

            result = inn.applyAML(AMLStr);

            return result;
        }

        Item AllItemtypes = null;

        private void parentItemTypeCBox_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("clicked");



        }

        void loadParentItemList()
        {
            if (AllItemtypes == null)
            {
                AllItemtypes = GetAllItemType();
            }

            for (int i = 0; i < AllItemtypes.getItemCount(); i++)
            {
                parentItemTypeCBox.Items.Add(AllItemtypes.getItemByIndex(i).getProperty("keyed_name"));
            }
        }
        Item parentItemType = null;
        private void parentItemTypeCBox_TextChanged(object sender, EventArgs e)
        {
            string parentItemtypeValue = parentItemTypeCBox.Text;

            childItemTypeCBox.Items.Clear();
            parentStuctRelCBox.Items.Clear();
            parentFileRelCBox.Items.Clear();

            parentItemType = GetItemType(parentItemtypeValue);

            //updating ChildItemtype List
            Item childItemtypeList = parentItemType.getItemsByXPath("//Item[@type='ItemType']//Item[@type='RelationshipType']/related_id/Item[@type='ItemType']");
            for (int i = 0; i < childItemtypeList.getItemCount(); i++)
            {
                childItemTypeCBox.Items.Add(childItemtypeList.getItemByIndex(i).getProperty("keyed_name"));
            }

            //updating parentStructure List

            Item structureItemtypeList = parentItemType.getItemsByXPath("//Item[@type='ItemType']//Item[@type='RelationshipType']/related_id/Item[@type='ItemType' and name='" + parentItemtypeValue + "']/../..");
            for (int i = 0; i < structureItemtypeList.getItemCount(); i++)
            {
                parentStuctRelCBox.Items.Add(structureItemtypeList.getItemByIndex(i).getProperty("keyed_name"));
            }

            //updating ChildItemtype List
            Item parentFileRelypeList = parentItemType.getItemsByXPath("//Item[@type='ItemType']//Item[@type='RelationshipType']/related_id/Item[@type='ItemType' and name='File']/../..");
            for (int i = 0; i < parentFileRelypeList.getItemCount(); i++)
            {
                parentFileRelCBox.Items.Add(parentFileRelypeList.getItemByIndex(i).getProperty("keyed_name"));
            }

            parentStuctRelCBox.Text = "";
            childItemTypeCBox.Text = "";
            parentFileRelCBox.Text = "";
        }

        private void childItemTypeCBox_TextChanged(object sender, EventArgs e)
        {
            if (parentItemType != null)
            {
                string childItemtypeValue = childItemTypeCBox.Text;

                parentChildRelCBox.Items.Clear();
                childStuctRelCBox.Items.Clear();
                childFileRelCBox.Items.Clear();


                Item childItemType = GetItemType(childItemtypeValue);

                //updating parentChildrel List
                Item parentchildReltypeList = parentItemType.getItemsByXPath("//Item[@type='ItemType']//Item[@type='RelationshipType']/related_id/Item[@type='ItemType' and name='" + childItemtypeValue + "']/../..");
                for (int i = 0; i < parentchildReltypeList.getItemCount(); i++)
                {
                    parentChildRelCBox.Items.Add(parentchildReltypeList.getItemByIndex(i).getProperty("keyed_name"));
                }

                //updating ChildItemtype List
                Item childStructReltypeList = childItemType.getItemsByXPath("//Item[@type='ItemType']//Item[@type='RelationshipType']/related_id/Item[@type='ItemType' and name='" + childItemtypeValue + "']/../..");
                for (int i = 0; i < childStructReltypeList.getItemCount(); i++)
                {
                    childStuctRelCBox.Items.Add(childStructReltypeList.getItemByIndex(i).getProperty("keyed_name"));
                }

                //updating ChildItemtype List
                //Item childFileReltypeList = childItemType.getItemsByXPath("//Item[@type='ItemType']//Item[@type='RelationshipType' and (./name[contains file] or ./related_id[contains file]    ]");
                //for (int i = 0; i < childFileReltypeList.getItemCount(); i++)
                //{
                //    childStuctRelCBox.Items.Add(childFileReltypeList.getItemByIndex(i).getProperty("keyed_name"));
                //}

                Item childFileReltypeList = childItemType.getItemsByXPath("//Item[@type='ItemType']//Item[@type='RelationshipType']");
                for (int i = 0; i < childFileReltypeList.getItemCount(); i++)
                {
                    Item relatedItem = childFileReltypeList.getItemByIndex(i).getRelatedItem();
                    String relationshipName = childFileReltypeList.getItemByIndex(i).getProperty("keyed_name");
                    if (relatedItem != null && relatedItem.getProperty("keyed_name").ToLower().Contains("file"))
                    {
                        childFileRelCBox.Items.Add(childFileReltypeList.getItemByIndex(i).getProperty("keyed_name"));

                    }
                    else if (relationshipName.ToLower().Contains("file"))
                    {
                        childFileRelCBox.Items.Add(relationshipName);
                    }
                }
                parentChildRelCBox.Text = "";
                childStuctRelCBox.Text = "";
                childFileRelCBox.Text = "";
            }
        }

        private void arasConfigApply_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["ParentType"].Value = parentItemTypeCBox.Text;
            config.AppSettings.Settings["ChildType"].Value = childItemTypeCBox.Text;
            config.AppSettings.Settings["ParentStructure"].Value = parentStuctRelCBox.Text;
            config.AppSettings.Settings["ChildStructure"].Value = childStuctRelCBox.Text;
            config.AppSettings.Settings["ParentChildRelation"].Value = parentChildRelCBox.Text;
            config.AppSettings.Settings["ParentFileRelation"].Value = parentFileRelCBox.Text;
            config.AppSettings.Settings["ChildFileRelation"].Value = childFileRelCBox.Text;
            config.AppSettings.Settings["FilesFolder"].Value = fileFolderTBox.Text;
            config.AppSettings.Settings["delimiter"].Value = delimiterTBox.Text;
            config.AppSettings.Settings["Delete_Files_OnRevise"].Value = deleteFilesOnRevCBox.Text;
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void arasConfigCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
