﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pulse.Documentos.Api {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Demos {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Demos() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Pulse.Documentos.Api.Demos", typeof(Demos).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;!-- 
        ///Invoice dynamically rendered into html using handlebars and converted into pdf
        ///using chrome-pdf recipe. The styles are extracted into separate asset for 
        ///better readability and later reuse.
        ///
        ///Data to this sample are mocked at the design time and should be filled on the 
        ///incoming API request.
        ///!--&gt;
        ///
        ///&lt;html&gt;
        ///    &lt;head&gt;
        ///        &lt;meta content=&quot;text/html; charset=utf-8&quot; http-equiv=&quot;Content-Type&quot;&gt;
        ///        &lt;style&gt;
        ///            .invoice-box {
        ///    max-width: 800px;
        ///    margin: auto;
        ///    padding: 20px;
        ///    border:  [rest of string was truncated]&quot;;.
        /// </summary>
        public static string Demo1 {
            get {
                return ResourceManager.GetString("Demo1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///    &quot;number&quot;: &quot;123&quot;,
        ///    &quot;seller&quot;: {
        ///        &quot;name&quot;: &quot;Next Step Webs, Inc.&quot;,
        ///        &quot;road&quot;: &quot;12345 Sunny Road&quot;,
        ///        &quot;country&quot;: &quot;Sunnyville, TX 12345&quot;
        ///    },
        ///    &quot;buyer&quot;: {
        ///        &quot;name&quot;: &quot;Sofia Calderon&quot;,
        ///        &quot;road&quot;: &quot;16 Johnson Road&quot;,
        ///        &quot;country&quot;: &quot;Paris, France 8060&quot;
        ///    },
        ///    &quot;items&quot;: [{
        ///        &quot;name&quot;: &quot;Website design&quot;,
        ///        &quot;price&quot;: 300
        ///    }]
        ///}.
        /// </summary>
        public static string Json1 {
            get {
                return ResourceManager.GetString("Json1", resourceCulture);
            }
        }
    }
}
