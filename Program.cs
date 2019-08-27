using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml;
using System.Linq;
using System.Xml.Schema;


namespace Notepad_for_git
{
using System.Xml;
using System.Xml.Schema;
using System.IO;

public class ValidXSD
{
    public static void Main()
    {

        // Set the validation settings.
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.ValidationType = ValidationType.Schema;
        settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
        settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
        settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
        settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

        // Create the XmlReader object.
        XmlReader reader = XmlReader.Create("inlineSchema.xml", settings);

        // Parse the file. 
        while (reader.Read()) ;

    }
    // Display any warnings or errors.
    private static void ValidationCallBack(object sender, ValidationEventArgs args)
    {
        if (args.Severity == XmlSeverityType.Warning)
            Console.WriteLine("\tWarning: Matching schema not found.  No validation occurred." + args.Message);
        else
            Console.WriteLine("\tValidation error: " + args.Message);

    }
}




    public class Student
    {
        public string Name{get;set;}
                public string Surname{get;set;}

        public static IEnumerable<Student> Students (){
            return new List<Student>();
        }
    }
    public class Program
    {
        public string Filename = "sss";
        static void Main(string[] args)
        {
            var xmlDoc = new XDocument(new XDeclaration("1.0", "uth-8", "yes"),
                                                                        new XElement("Students",
                                                                        Student.Students().Select(item=> new XElement("Student", new XAttribute("Id", item.Name),
                                                                        new XElement ("sss", item.Surname)))));




        }

        public void ValidateXML(string d){
            d = Filename;
            XmlReader xmlReader = null;
            try{
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= System.Xml.Schema.XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= System.Xml.Schema.XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler+=new ValidationEventHandler(this.ValidationEventHandle);

            xmlReader = XmlReader.Create(Filename, settings);
            while (xmlReader.Read())
            {
                Console.WriteLine("ItsOk");                
            }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);                

            }
            finally{
                if(xmlReader!=null){
                    xmlReader.Close();
                }
            }



        }
        private void ValidationEventHandle (object sender, ValidationEventArgs args){
            Console.WriteLine("ValidationFailed");
            throw new Exception("Error");

        }



    }


}
