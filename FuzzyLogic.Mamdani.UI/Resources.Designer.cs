﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Forms {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Forms.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на &lt;problemConditions&gt;
        ///	&lt;variables&gt;
        ///		&lt;variable name=&quot;X1&quot;&gt;
        ///			&lt;term name=&quot;низкий&quot; 	a=&quot;0.0&quot; b=&quot;0.0&quot; c=&quot;0.3&quot; d=&quot;0.4&quot; /&gt;
        ///			&lt;term name=&quot;средний&quot; 	a=&quot;0.3&quot; b=&quot;0.4&quot; c=&quot;0.6&quot; d=&quot;0.7&quot; /&gt;
        ///			&lt;term name=&quot;высокий&quot; 	a=&quot;0.6&quot; b=&quot;0.7&quot; c=&quot;1.0&quot; d=&quot;1.0&quot; /&gt;
        ///		&lt;/variable&gt;
        ///		&lt;variable name=&quot;X2&quot;&gt;
        ///			&lt;term name=&quot;неуд&quot; 	a=&quot;0.0&quot; b=&quot;0.0&quot; c=&quot;0.4&quot; d=&quot;0.5&quot; /&gt;
        ///			&lt;term name=&quot;уд&quot; 	a=&quot;0.4&quot; b=&quot;0.5&quot; c=&quot;0.6&quot; d=&quot;0.7&quot; /&gt;
        ///			&lt;term name=&quot;хор&quot; 	a=&quot;0.6&quot; b=&quot;0.7&quot; c=&quot;0.8&quot; d=&quot;0.9&quot; /&gt;
        ///			&lt;term name=&quot;отл&quot; 	a=&quot;0.8&quot; b=&quot;0.9&quot; c=&quot;1.0&quot; d=&quot;1.0&quot; /&gt;
        ///		&lt;/variable&gt;
        ///		 [остаток строки не уместился]&quot;;.
        /// </summary>
        internal static string input1 {
            get {
                return ResourceManager.GetString("input1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на &lt;problemConditions&gt;
        ///	&lt;variables&gt;
        ///		&lt;variable name=&quot;X1&quot;&gt;
        ///			&lt;term name=&quot;отсутствует&quot; 	a=&quot;0.0&quot; b=&quot;0.0&quot; c=&quot;0.1&quot; d=&quot;0.2&quot; /&gt;
        ///			&lt;term name=&quot;низкая&quot; 		a=&quot;0.1&quot; b=&quot;0.2&quot; c=&quot;0.3&quot; d=&quot;0.4&quot; /&gt;
        ///			&lt;term name=&quot;средняя&quot; 		a=&quot;0.3&quot; b=&quot;0.4&quot; c=&quot;0.6&quot; d=&quot;0.7&quot; /&gt;
        ///			&lt;term name=&quot;высокая&quot; 		a=&quot;0.6&quot; b=&quot;0.7&quot; c=&quot;0.85&quot; d=&quot;0.95&quot; /&gt;
        ///			&lt;term name=&quot;полное&quot; 		a=&quot;0.85&quot; b=&quot;0.95&quot; c=&quot;1.0&quot; d=&quot;1.0&quot; /&gt;
        ///		&lt;/variable&gt;
        ///		
        ///		&lt;variable name=&quot;X2&quot;&gt;
        ///			&lt;term name=&quot;отсутствует&quot; 	a=&quot;0.0&quot; b=&quot;0.0&quot; c=&quot;0.1&quot; d=&quot;0.2&quot; /&gt;
        ///			&lt;term name=&quot;низкая&quot; 		a=&quot;0.1&quot; b=&quot;0.2&quot; c [остаток строки не уместился]&quot;;.
        /// </summary>
        internal static string input2 {
            get {
                return ResourceManager.GetString("input2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на &lt;problemConditions&gt;
        ///	&lt;variables&gt;
        ///		&lt;variable name=&quot;X1&quot;&gt;
        ///			&lt;term name=&quot;низкий&quot; 	a=&quot;0.0&quot; b=&quot;0.0&quot; c=&quot;0.3&quot; d=&quot;0.4&quot; /&gt;
        ///			&lt;term name=&quot;средний&quot; 	a=&quot;0.3&quot; b=&quot;0.4&quot; c=&quot;0.6&quot; d=&quot;0.7&quot; /&gt;
        ///			&lt;term name=&quot;высокий&quot; 	a=&quot;0.6&quot; b=&quot;0.7&quot; c=&quot;1.0&quot; d=&quot;1.0&quot; /&gt;
        ///		&lt;/variable&gt;
        ///		&lt;variable name=&quot;X2&quot;&gt;
        ///			&lt;term name=&quot;неуд&quot; 	a=&quot;0.0&quot; b=&quot;0.0&quot; c=&quot;0.4&quot; d=&quot;0.5&quot; /&gt;
        ///			&lt;term name=&quot;уд&quot; 	a=&quot;0.4&quot; b=&quot;0.5&quot; c=&quot;0.6&quot; d=&quot;0.7&quot; /&gt;
        ///			&lt;term name=&quot;хор&quot; 	a=&quot;0.6&quot; b=&quot;0.7&quot; c=&quot;0.8&quot; d=&quot;0.9&quot; /&gt;
        ///			&lt;term name=&quot;отл&quot; 	a=&quot;0.8&quot; b=&quot;0.9&quot; c=&quot;1.0&quot; d=&quot;1.0&quot; /&gt;
        ///		&lt;/variable&gt;
        ///		 [остаток строки не уместился]&quot;;.
        /// </summary>
        internal static string input3 {
            get {
                return ResourceManager.GetString("input3", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap TrapFuncDescription {
            get {
                object obj = ResourceManager.GetObject("TrapFuncDescription", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
