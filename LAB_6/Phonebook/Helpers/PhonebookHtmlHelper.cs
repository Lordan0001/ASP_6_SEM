using Phonebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phonebook.Helpers
{
    public static class PhonebookHtmlHelpers
    {
        public static MvcHtmlString NewPhonebookEntry(this HtmlHelper html)
        {
            var form = new TagBuilder("form");
            form.Attributes.Add("method", "post");
            form.Attributes.Add("action", "AddSave");

            var div1 = new TagBuilder("div");
            div1.Attributes.Add("class", "form-group");

            var label1 = new TagBuilder("label");
            label1.Attributes.Add("for", "LastName");
            label1.InnerHtml = "Last Name:";

            var input1 = new TagBuilder("input");
            input1.Attributes.Add("class", "form-control");
            input1.Attributes.Add("type", "text");
            input1.Attributes.Add("id", "LastName");
            input1.Attributes.Add("name", "LastName");

            var div2 = new TagBuilder("div");
            div2.Attributes.Add("class", "form-group");

            var label2 = new TagBuilder("label");
            label2.Attributes.Add("for", "Phone");
            label2.InnerHtml = "Phone:";

            var input2 = new TagBuilder("input");
            input2.Attributes.Add("class", "form-control");
            input2.Attributes.Add("type", "text");
            input2.Attributes.Add("id", "Phone");
            input2.Attributes.Add("name", "Phone");

            var submit = new TagBuilder("button");
            submit.Attributes.Add("type", "submit");
            submit.Attributes.Add("class", "btn btn-default");
            submit.InnerHtml = "Save";

            div1.InnerHtml = label1.ToString() + input1.ToString();
            div2.InnerHtml = label2.ToString() + input2.ToString();

            form.InnerHtml = div1.ToString() + div2.ToString() + submit.ToString();

            return MvcHtmlString.Create(form.ToString());
        }

        public static MvcHtmlString EditPhonebookEntry(this HtmlHelper html, HandbookRecord model)
        {
            var form = new TagBuilder("form");
            form.Attributes.Add("method", "post");
            form.Attributes.Add("action", "https://localhost:44376/Dict/UpdateSave");

            var div1 = new TagBuilder("div");
            div1.Attributes.Add("class", "form-group");

            var label1 = new TagBuilder("label");
            label1.Attributes.Add("for", "LastName");
            label1.InnerHtml = "Last Name:";

            var input1 = new TagBuilder("input");
            input1.Attributes.Add("class", "form-control");
            input1.Attributes.Add("type", "text");
            input1.Attributes.Add("id", "LastName");
            input1.Attributes.Add("name", "LastName");
            input1.Attributes.Add("value", model.LastName);

            var div2 = new TagBuilder("div");
            div2.Attributes.Add("class", "form-group");

            var label2 = new TagBuilder("label");
            label2.Attributes.Add("for", "Phone");
            label2.InnerHtml = "Phone:";

            var input2 = new TagBuilder("input");
            input2.Attributes.Add("class", "form-control");
            input2.Attributes.Add("type", "text");
            input2.Attributes.Add("id", "Phone");
            input2.Attributes.Add("name", "Phone");
            input2.Attributes.Add("value", model.Phone);

            var idInput = new TagBuilder("input");
            idInput.Attributes.Add("type", "hidden");
            idInput.Attributes.Add("name", "Id");
            idInput.Attributes.Add("value", model.Id.ToString());

            var submit = new TagBuilder("button");
            submit.Attributes.Add("type", "submit");
            submit.Attributes.Add("class", "btn btn-default");
            submit.InnerHtml = "Save";

            div1.InnerHtml = label1.ToString() + input1.ToString();
            div2.InnerHtml = label2.ToString() + input2.ToString();

            form.InnerHtml = idInput.ToString() +  div1.ToString() + div2.ToString() + submit.ToString();

            return MvcHtmlString.Create(form.ToString());
        }
    }
}