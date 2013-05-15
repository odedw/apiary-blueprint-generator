using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ApiaryBlueprintGenerator.Models;
using ApiaryBlueprintGenerator.Models.Tags;

namespace ApiaryBlueprintGenerator.Logic
{
    public class BlueprintCreator
    {
        public void Create(DocumentationModel model, string outputFilename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(outputFilename))
                {
                    WriteModel(model, writer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create blueprint: " + ex);
            }
        }

        private void WriteModel(DocumentationModel model, StreamWriter writer)
        {
            //write HOST if exists
            if (!string.IsNullOrEmpty(model.Host))
                writer.WriteLine("HOST: {0}{1}", model.Host, Environment.NewLine);

            writer.WriteLine("--- {0} ---", model.Title);

            //write Description if exists
            if (!string.IsNullOrEmpty(model.Description))
                writer.WriteLine("---{1}{0}{1}---", model.Description, Environment.NewLine);

            writer.WriteLine();

            //Write all the sections
            foreach (var sectionModel in model.Sections)
            {
                WriteSection(writer, sectionModel);
            }
        }

        private void WriteSection(StreamWriter writer, SectionModel sectionModel)
        {
            //Write section header and description (if exists)
            TitleTag title = GetTagOfType<TitleTag>(sectionModel.SectionTags);
            SummaryTag summary = GetTagOfType<SummaryTag>(sectionModel.SectionTags);
            if (summary != null)
            {
                writer.WriteLine("--{2}{0}{2}{1}{2}--", title.Text, summary.Text, Environment.NewLine);
            }
            else
            {
                writer.WriteLine("-- {0} --", title.Text, Environment.NewLine);
            }

            foreach (var resourceModel in sectionModel.Resources)
            {
                WriteResource(resourceModel, writer);
            }
        }

        private void WriteResource(ResourceModel resourceModel, StreamWriter writer)
        {
            //Resource header and description
            SummaryTag summary = GetTagOfType<SummaryTag>(resourceModel.Tags);
            if (summary != null)
            {
                writer.WriteLine(summary.Text);
            }

            //Resource HTTP method and path
            ResourceTag resourceTag = GetTagOfType<ResourceTag>(resourceModel.Tags);
            writer.WriteLine("{0} {1}", resourceTag.HttpMethod, resourceTag.Text);

            //Request headers
            HeadersTag headersTag = GetTagOfType<HeadersTag>(resourceModel.Tags);
            if (headersTag != null)
                foreach (var kvp in headersTag.Request)
                    writer.WriteLine("> {0}: {1}", kvp.Key, kvp.Value);

            //Input example
            ExampleTag exampleTag = GetTagOfType<ExampleTag>(resourceModel.Tags);
            if (exampleTag != null && !string.IsNullOrEmpty(exampleTag.InputExample))
                writer.WriteLine(exampleTag.InputExample);

            // HTTP status code
            ReturnsTag returnsTag = GetTagOfType<ReturnsTag>(resourceModel.Tags);
            writer.WriteLine("< {0}", returnsTag != null ? returnsTag.StatusCode : ReturnsTag.DEFAULT_STATUS_CODE.ToString());

            //Response headers
            if (headersTag != null)
                foreach (var kvp in headersTag.Response)
                    writer.WriteLine("< {0}: {1}", kvp.Key, kvp.Value);

            //Output example
            if (exampleTag != null && !string.IsNullOrEmpty(exampleTag.OutputExample))
                writer.WriteLine(exampleTag.OutputExample);

            //Two empty lines before the next resource
            writer.WriteLine(Environment.NewLine);
        }

        private T GetTagOfType<T>(IEnumerable<ITag> tags) where T : class
        {
            T tag = tags.FirstOrDefault(t => t as T != null) as T;
            return tag;

        }
    }

}
