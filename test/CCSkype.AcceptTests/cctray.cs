﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=2.0.50727.3038.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class Projects {
    
    private ProjectsProject[] itemsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Project", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public ProjectsProject[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ProjectsProject {
    
    private string nameField;
    
    private string activityField;
    
    private string lastBuildStatusField;
    
    private string lastBuildLabelField;
    
    private string lastBuildTimeField;
    
    private string webUrlField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string activity {
        get {
            return this.activityField;
        }
        set {
            this.activityField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string lastBuildStatus {
        get {
            return this.lastBuildStatusField;
        }
        set {
            this.lastBuildStatusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string lastBuildLabel {
        get {
            return this.lastBuildLabelField;
        }
        set {
            this.lastBuildLabelField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string lastBuildTime {
        get {
            return this.lastBuildTimeField;
        }
        set {
            this.lastBuildTimeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string webUrl {
        get {
            return this.webUrlField;
        }
        set {
            this.webUrlField = value;
        }
    }
}
