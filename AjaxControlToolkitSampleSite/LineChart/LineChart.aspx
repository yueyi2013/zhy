<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.master" AutoEventWireup="true"
    CodeFile="LineChart.aspx.cs" Inherits="LineChart_LineChart" Title="LineChart Sample"
    Culture="auto" UICulture="auto" Theme="SampleSiteTheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="demoarea">
        <div class="demoheading">
            LineChart Demonstration</div>
        <br />
        <strong>Basic Type:</strong>
        <ajaxToolkit:LineChart ID="LineChart1" runat="server" ChartHeight="300" ChartWidth="450"
            ChartTitle="United States versus European Widget Production" CategoriesAxis="2007,2008,2009,2010,2011,2012"
            ChartType="Basic" ChartTitleColor="#0E426C" CategoryAxisLineColor="#D08AD9" ValueAxisLineColor="#D08AD9"
            BaseLineColor="#A156AB" AreaDataLabel=" thousands">
            <Series>
                <ajaxToolkit:LineChartSeries Name="United States" LineColor="#6C1E83" Data="110, 189, 255, 95, 107, 140" />
                <ajaxToolkit:LineChartSeries Name="Europe" LineColor="#D08AD9" Data="49, 77, 95, 68, 70, 79" />                
            </Series>
        </ajaxToolkit:LineChart>
        <br />
        <strong>Stacked Type:</strong>
        <ajaxToolkit:LineChart ID="LineChart2" runat="server" ChartHeight="300" ChartWidth="450"
            ChartTitle="United States versus European Widget Production" CategoriesAxis="2007,2008,2009,2010,2011,2012"
            ChartType="Stacked" ChartTitleColor="#0E426C" CategoryAxisLineColor="#D08AD9"
            ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB" AreaDataLabel=" thousands">
            <Series>
                <ajaxToolkit:LineChartSeries Name="United States" LineColor="#6C1E83" Data="110, 189, 255, 95, 107, 140" />
                <ajaxToolkit:LineChartSeries Name="Europe" LineColor="#D08AD9" Data="49, 77, 95, 68, 70, 79" />
            </Series>
        </ajaxToolkit:LineChart>
        <br />
    </div>
    <div class="demobottom">
    </div>
    <asp:Panel ID="Description_HeaderPanel" runat="server" Style="cursor: pointer;">
        <div class="heading">
            <asp:ImageButton ID="Description_ToggleImage" runat="server" ImageUrl="~/images/collapse.jpg"
                AlternateText="collapse" />
            LineChart Description
        </div>
    </asp:Panel>
    <asp:Panel ID="Description_ContentPanel" runat="server" Style="overflow: hidden;">
        <p>
            The LineChart control enables you to render a line chart from one or more series
            of values. This control is compatible with any browser which supports SVG including
            Internet Explorer 9 and above.
        </p>
        <br />
        <p>
            This control can display two types of LineCharts: Basic and Stacked.
        </p>
    </asp:Panel>
    <asp:Panel ID="Properties_HeaderPanel" runat="server" Style="cursor: pointer;">
        <div class="heading">
            <asp:ImageButton ID="Properties_ToggleImage" runat="server" ImageUrl="~/images/expand.jpg"
                AlternateText="expand" />
            LineChart Properties
        </div>
    </asp:Panel>
    <asp:Panel ID="Properties_ContentPanel" runat="server" Style="overflow: hidden;"
        Height="0px">
        <p>
            The control above is initialized with this code. The <em>italic</em> properties
            are optional:</p>
        <pre>
&lt;ajaxToolkit:LineChart ID=&quot;LineChart1&quot; runat=&quot;server&quot; 
<em>ChartWidth</em>=&quot;450&quot; <em>ChartHeight</em>=&quot;300&quot; ChartType=&quot;Basic&quot; 
<em>ChartTitle</em>=&quot;United States versus European Widget Production&quot; 
CategoriesAxis=&quot;2007,2008,2009,2010,2011,2012&quot; 
<em>ChartTitleColor</em>=&quot;#0E426C&quot; <em>CategoryAxisLineColor</em>=&quot;#D08AD9&quot; 
<em>ValueAxisLineColor</em>=&quot;#D08AD9&quot; <em>BaseLineColor</em>=&quot;#A156AB&quot;&gt;
&lt;Series&gt;
    &lt;ajaxToolkit:LineChartSeries Name=&quot;United States&quot; 
    <em>LineColor</em>=&quot;#6C1E83&quot; Data=&quot;110, 189, 255, 95, 107, 140&quot; /&gt;
    &lt;ajaxToolkit:LineChartSeries Name=&quot;Europe&quot;  
    <em>LineColor</em>=&quot;#D08AD9&quot; Data=&quot;49, 77, 95, 68, 70, 79&quot; /&gt;
&lt;/Series&gt;
&lt;/ajaxToolkit:LineChart&gt;
    </pre>
        <strong>LineChart Properties</strong>
        <ul>
            <li><strong>ChartHeight</strong> - This property enables you to customize the height
                of the chart.</li>
            <li><strong>ChartWidth</strong> - This property enables you to customize the width of
                the chart.</li>
            <li><strong>ChartTitle</strong> - This property enables you to set the title of the
                chart.</li>
            <li><strong>CategoryAxis</strong> - This is a required property. You need to provide
                a set of values for the category axis to create a line chart.</li>
            <li><strong>ChartType</strong> - This property enables you to render two types of line 
            charts 1. Basic 2. Stacked.</li>
            <li><strong>Theme</strong> - This property enables you to control the appearance of
                the line chart with a Cascading Style Sheet file.</li>
            <li><strong>ValueAxisLines</strong> - This property enables you to set the interval
                size for the value axis line.</li>
            <li><strong>ChartTitleColor</strong> - This property enables you to set the font color
                of the chart title.</li>
            <li><strong>CategoryAxisLineColor</strong> - This property enables you to set the color
                of the category axis lines.</li>
            <li><strong>ValueAxisLineColor</strong> - This property enables you to set the the color
                of the value axis lines.</li>
            <li><strong>BaseLineColor</strong> - This property enables you to set the color of the
                base lines of the chart.</li>
            <li><strong>TooltipBackgroundColor</strong> - This property enables you to set the background 
                color of the tooltip box.</li>
            <li><strong>TooltipFontColor</strong> - This property enables you to set the font 
                color of the tooltip box.</li>
            <li><strong>TooltipBorderColor</strong> - This property enables you to set the border 
                color of the tooltip box.</li>            
            <li><strong>AreaDataLabel</strong> - This property enables you to set the text/label that will be shown
                in the tooltip and describe about area data value.</li>
        </ul>
        <br />
        <strong>LineChartSeries Properties:</strong>
        <ul>
            <li><strong>Name</strong> - This property is required.</li>
            <li><strong>Data</strong> - This property is required and provides data for a particular
                series.</li>
            <li><strong>LineColor</strong> - This property enables you to set the color of line
                for a particular series.</li>
        </ul>
        <br />
    </asp:Panel>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeDescription" runat="Server" TargetControlID="Description_ContentPanel"
        ExpandControlID="Description_HeaderPanel" CollapseControlID="Description_HeaderPanel"
        Collapsed="False" ImageControlID="Description_ToggleImage" />
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeProperties" runat="Server" TargetControlID="Properties_ContentPanel"
        ExpandControlID="Properties_HeaderPanel" CollapseControlID="Properties_HeaderPanel"
        Collapsed="True" ImageControlID="Properties_ToggleImage" />
</asp:Content>
