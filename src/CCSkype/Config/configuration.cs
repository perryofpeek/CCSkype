
using System.Collections.Generic;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class Configuration
{
    private ConfigurationPipeline[] itemsField;

    private string _cctrayUri;
    private string _pollTime;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Pipeline", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public ConfigurationPipeline[] Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
        }
    }

    public void Add(string pipeline, string skypename)
    {
        //if(Items == null)
        //{
        //    Items = new ConfigurationPipeline[0];
        //}

        var temp = new List<ConfigurationPipeline>();
        var added = false;
        foreach (ConfigurationPipeline item in Items)
        {
            if(item.name == pipeline)
            {
                var shouldAdd = true;
                foreach (var user in item.users)
                {
                    if(user.skypeName == skypename)
                    {
                        shouldAdd = false;
                    }
                }
                if(shouldAdd)
                {
                    var lstTest = new List<ConfigurationPipelineUsersUser>(item.users);
                    lstTest.Add(new ConfigurationPipelineUsersUser() {skypeName = item.name});
                    item.users = lstTest.ToArray();
                }                                
            }
            temp.Add(item);
        }

        temp.Add(new ConfigurationPipeline() {name = pipeline,});
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ConfigurationPipeline
{

    private ConfigurationPipelineUsersUser[] usersField;

    private string nameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("user", typeof(ConfigurationPipelineUsersUser), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    public ConfigurationPipelineUsersUser[] users
    {
        get
        {
            return this.usersField;
        }
        set
        {
            this.usersField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ConfigurationPipelineUsersUser
{

    private string skypeNameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string skypeName
    {
        get
        {
            return this.skypeNameField;
        }
        set
        {
            this.skypeNameField = value;
        }
    }
}
