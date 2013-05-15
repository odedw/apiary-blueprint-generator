#Apiary Blueprint Generator

Generate an Apiary blueprint from a .Net XML documentation file. Integrate into your deployment process and use Apiary's future API to upload the blueprint for a full solution.
Every class is considered to be a section, and every method is considered to be a resource.

##Usage

The blueprint generator is a command line application. It accepts the following parameters:
<dl>
  <dt>Input file name (Required)</dt>
  <dd>The name of the input XML file</dd>
  <dt>Output file name (Required)</dt>
  <dd>The name of the output txt file</dd>
  <dt>API documentation title (Required)</dt>
  <dd>The Title for the API documentation</dd>
  <dt>Host address (Optional)</dt>
  <dd>The host address for the real server</dd>
  <dt>API documentation description (Optional)</dt>
  <dd>The description for the API</dd>
  <dt>Desired clasess namespace prefix (Optional)</dt>
  <dd>The desired controllers namespace (all other documentation will be filtered out)</dd>
</dl>


Example usage:
```
ApiaryBlueprintGenerator.exe ..\..\..\ShoppingCartExample\bin\ShoppingCartExample.XML ShoppingCartExample.txt "Sample API v2" 
-d "Welcome to the our sample API documentation." -h http://www.google.com/ -n ShoppingCartExample.Controllers
```

##Documentation Tags

####Class Tags
<table>
  <tr>
    <th>Tag</th><th>Description</th><th>Required</th>
  </tr>
  <tr>
	<td>&lt;title&gt;</td>
	<td>The section's title</td>
	<td>✓</td>
  </tr>
  <tr>
	<td>&lt;summary&gt;</td>
	<td>The section's description</td>
	<td></td>
  </tr>
</table>

####Method Tags
<table>
  <tr>
    <th>Tag</th><th>Description</th><th>Attributes</th><th>Required</th>
  </tr>
  <tr>
	<td>&lt;summary&gt;</td>
	<td>The resource's description</td>
	<td></td>
	<td></td>
  </tr>
  <tr>
	<td>&lt;resource&gt;</td>
	<td>The resource's path (element value) and HTTP method (attribute)</td>
	<td>method</td>
	<td>✓</td>
  </tr>
  <tr>
	<td>&lt;headers&gt;</td>
	<td>A list of &lt;request&gt; or &lt;response&gt; elements containing headers to be returned from the resource</td>
	<td></td>
	<td></td>
  </tr>
  <tr>
	<td>&lt;request&gt;</td>
	<td>A header to be included in the request (nested in the &lt;headers&gt; tag)</td>
	<td>name</td>
	<td></td>
  </tr>
  <tr>
	<td>&lt;response&gt;</td>
	<td>A header to be included in the response (should be nested in the &lt;headers&gt; tag)</td>
	<td>name</td>
	<td></td>
  </tr>
  <tr>
	<td>&lt;returns&gt;</td>
	<td>Contains (in an attribute) the HTTP status code that is expected from this resource, The default code is 200</td>
	<td>status-code</td>
	<td></td>
  </tr>
  <tr>
	<td>&lt;example&gt;</td>
	<td>Contains (in nested &lt;code&gt; tags) input and output value examples</td>
	<td></td>
	<td></td>
  </tr>
  <tr>
	<td>&lt;code&gt;</td>
	<td>Contains an input/output (stated in the type attribute) value example(should be nested in the &lt;example&gt; tag)</td>
	<td>type</td>
	<td></td>
  </tr>
</table>

Check out the shopping cart example project to see a properly documented project.

##Extention
* To add more tags just add a class that implements the `ITag` interface or the `BaseTag` class.
* To change the output check out the BlueprintCreator class

##Licence

(The MIT License)

Copyright (c) 2013 Oded Welgreen ApiaryBlueprintGenerator@outlook.com

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the 'Software'), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.