#pragma checksum "E:\VS Working\.net core\Lunch\Lunch.Admin\Views\FoodMenu\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4a5b6d2bcac26b628f4d2a9586b710dc8b8e2f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FoodMenu_Index), @"mvc.1.0.view", @"/Views/FoodMenu/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4a5b6d2bcac26b628f4d2a9586b710dc8b8e2f9", @"/Views/FoodMenu/Index.cshtml")]
    public class Views_FoodMenu_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<script type=\"text/template\" id=\"foodMenuList\">\r\n    <div>\r\n        <div style=\"text-align: right\">\r\n            <el-button type=\"success\" ");
            WriteLiteral(@"@click=""addFoodMenu()"">添加菜品</el-button>
        </div>
        <el-table :data=""tableData""
                  style=""width: 100%"">
            <el-table-column prop=""name"" width=""120""
                             label=""菜名"">
            </el-table-column>
            <el-table-column prop=""description""
                             label=""简介"">
            </el-table-column>
            <el-table-column prop=""stockCount"" width=""100""
                             label=""库存"">
            </el-table-column>
            <el-table-column prop=""type"" width=""100""
                             label=""类别"">
            </el-table-column>
            <el-table-column prop=""price"" width=""100"" :formatter=""format""
                             label=""价格"">
            </el-table-column>
            <el-table-column prop=""imgUrl"" width=""150""
                             label=""图样"">
                <template slot-scope=""scope"">
                    <img :src=""'/FoodMenu/ViewImge?id=' + scope.row.id"" min-width=""");
            WriteLiteral(@"100"" height=""100"" />
                </template>
            </el-table-column>

            <el-table-column fixed=""right""
                             label=""操作""
                             width=""180"">
                <template slot-scope=""scope"">
                    <el-button ");
            WriteLiteral("@click=\"editFoodMenu(scope.row)\" type=\"success\" size=\"small\">\r\n                        编辑\r\n                    </el-button>\r\n                    <el-button ");
            WriteLiteral(@"@click=""deleteFoodMenu(scope.row.id)"" type=""danger"" size=""small"">
                        删除
                    </el-button>
                </template>
            </el-table-column>
        </el-table>

        <el-pagination background
                       ");
            WriteLiteral("@size-change=\"pageSizeChange\"\r\n                       ");
            WriteLiteral(@"@current-change=""pageCurrentChange""
                       :page-size=""pagerOpt.pageSize""
                       :current-page=""pagerOpt.page""
                       :total=""pagerOpt.total""
                       :page-sizes=""[2, 10, 20, 50, 100]""
                       layout=""total, sizes, prev, pager, next, jumper"">
        </el-pagination>

        <el-dialog :title=""editType"" :visible.sync=""addFoodVisible"">
            <el-form :model=""form"">
                <el-form-item label=""菜名"" :label-width=""formLabelWidth"">
                    <el-input v-model=""form.Name"" autocomplete=""off""></el-input>
                </el-form-item>
                <el-form-item label=""表述"" :label-width=""formLabelWidth"">
                    <el-input v-model=""form.Description"" autocomplete=""off""></el-input>
                </el-form-item>
                <el-form-item label=""价格"" :label-width=""formLabelWidth"">
                    <el-input v-model=""form.Price"" autocomplete=""off""></el-input>
                </el-fo");
            WriteLiteral(@"rm-item>
                <el-form-item label=""库存"" :label-width=""formLabelWidth"">
                    <el-input v-model=""form.StockCount"" autocomplete=""off""></el-input>
                </el-form-item>
                <el-form-item label=""分类"" :label-width=""formLabelWidth"">
                    <el-input v-model=""form.Type"" autocomplete=""off""></el-input>
                </el-form-item>
                <el-form-item label=""图样"" :label-width=""formLabelWidth"">
                    <el-upload class=""avatar-uploader""
                               action=""/FoodMenu/UploadImg""
                               :show-file-list=""false""
                               :on-success=""handleAvatarSuccess""
                               :before-upload=""beforeAvatarUpload"">
                        <img v-if=""form.ImgUrl"" :src=""form.ImgUrl"" class=""avatar"" width=""120"" height=""120"">
                        <i v-else class=""el-icon-plus avatar-uploader-icon""></i>
                    </el-upload>
                </el-form-");
            WriteLiteral("item>\r\n            </el-form>\r\n            <div slot=\"footer\" class=\"dialog-footer\">\r\n                <el-button ");
            WriteLiteral("@click=\"closeDialog()\">取 消</el-button>\r\n                <el-button type=\"primary\" ");
            WriteLiteral(@"@click=""submitFoodMenu()"">确 定</el-button>
            </div>
        </el-dialog>
    </div>
</script>

<script type=""text/javascript"">
    var foodMenu = {
        template: '#foodMenuList',
        data() {
            return {
                saveUrl: ""/Food/UploadImg"",
                tableData: [],

                pagerOpt: {
                    pageSize: 20,
                    page: 1,
                    total: 0,
                },

                form: {
                    Id: 0,
                    Name: """",
                    Description: """",
                    Price: 0,
                    StockCount: 0,
                    Type: """",
                    ImgUrl: """",
                    ContentType: """"
                },

                editType: ""添加"",
                backup: {},
                addFoodVisible: false,
                formLabelWidth: '80px'
            }
        },
        mounted() {
            this.getData();
        },
        method");
            WriteLiteral(@"s: {
            getData() {
                var params = `pageNo=${this.pagerOpt.page}&pageSize=${this.pagerOpt.pageSize}`
                _fetch(""/FoodMenu/GetFoodMenus?"" + params, ""GET"").then(res => {
                    if (res.status = ""Success"") {

                        res.data.filter(x => {
                            x.checked = false;
                            x.isEdit = false;
                        });
                        this.tableData = res.data;
                        this.pagerOpt.total = res.total;
                    }
                    else {
                        alert(""系统出错了！"");
                    }
                });
            },

            addFoodMenu() {
                this.editType = ""添加菜品"";
                this.addFoodVisible = true;
            },

            deleteFoodMenu(id) {
               _fetch(""/FoodMenu/DeleteFoodMenu?id="" + id, ""POST"").then(res => {
                    if (res.status == true) {
                        alert(");
            WriteLiteral(@"""操作成功！"");
                        this.getData();
                    }
                    else {
                        alert(""系统出错了！"");
                    }
                });
            },

            editFoodMenu(row) {
                this.editType = ""修改菜品"";
                this.form = {
                    Id: row.id,
                    Name: row.name,
                    Description: row.description,
                    Price: row.price,
                    StockCount: row.stockCount,
                    Type: row.type,
                    ImgUrl: row.imgUrl,
                    ContentType: row.imageType,
                };
                this.addFoodVisible = true;
            },

            format(row, column) {
                var val = row.price.toFixed(2);

                return `￥${val}元`;
            },

            dateFormatter (row, column) {
                let datetime = row.time;
                if(datetime){
                    datetime = new Da");
            WriteLiteral(@"te(datetime);
                    let y = datetime.getFullYear() + '-';
                    let mon = datetime.getMonth()+1 + '-';
                    let d = datetime.getDate();
                    return y + mon + d;
                }
                return ''
            },

            closeDialog() {
                this.form = {
                    Id: 0,
                    Name: """",
                    Description: """",
                    Price: """",
                    StockCount: """",
                    Type: """",
                    ImgUrl: """",
                    ContentType: """"
                };

               this.addFoodVisible = false;
            },

            submitFoodMenu() {
                if (!this.form.Name || !this.form.Description || !this.form.Price
                    || !this.form.StockCount || !this.form.Type || !this.form.ImgUrl) {
                    alert(""请完成下面所有信息！"")
                    return;
                }

                var model = $");
            WriteLiteral(@".extend(true, {}, this.form);
                var data = {
                    Id: model.Id,
                    Name: model.Name,
                    Description: model.Description,
                    ImgUrl: model.ImgUrl,
                    ContentType: model.ContentType,
                    Type: model.Type,
                    Price: parseFloat(model.Price),
                    StockCount: parseFloat(model.StockCount),
                }

                _fetch(""/FoodMenu/AddFoodMenu"", ""POST"", data).then(res => {
                    if (res.status == true) {
                        alert(""操作成功！"");
                        this.closeDialog();
                        this.getData();
                        this.addFoodVisible = false;
                    }
                    else {
                        alert(""系统出错了！"");
                    }
                });
            },

            editOrder() {
                var ids = [];
                this.tableData.filter(v => {
");
            WriteLiteral(@"                    if (v.checked) {
                        ids.push(v.id);
                    }
                });

                if (ids.length == 0 || ids.length > 1) {
                    alert('请先选择一份菜品');
                    return;
                }

                var item = this.tableData.find(x => x.id == ids[0]);
                item.isEdit = true;
                this.backup = item.status;
            },

            cancelOrder(item) {
                item.isEdit = false;
                item.status = this.backup;
            },

            saveOrder(item) {
                var parms = `id=${item.id}&status=${item.status}`
                _fetch(""/Order/Save?"" + parms, ""Post"").then(res => {
                    if (res.status = ""Success"") {
                        this.getData();
                    }
                    else {
                        alert(""系统出错了！"");
                    }
                });
            },

            deleteOrder() {
     ");
            WriteLiteral(@"           var ids = [];
                this.tableData.forEach(function (v) {
                    if (v.checked) {
                        ids.push(v.id);
                    }
                });
                if (ids.length == 0) {
                    alert('请先选择一份菜品');
                    return;
                }

                alert(""删除成功！"");
            },

             pageSizeChange(val) {
                this.pagerOpt.pageSize = val;
                this.getData();
            },

            pageCurrentChange(val) {
                this.pagerOpt.page = val;
                this.getData();
            },

            handleAvatarSuccess(res, file) {
                this.form.ImgUrl = res.fileName;
                this.form.ContentType = res.type;
            },

            beforeAvatarUpload(file) {
                const isJPG = file.type === 'image/jpeg';
                const isLt2M = file.size / 1024 / 1024 < 2;

                if (!isJPG) {
               ");
            WriteLiteral("     alert(\'上传图片只能是 JPG 格式!\');\r\n                    return;\r\n                }\r\n                if (!isLt2M) {\r\n                    alert(\'上传图片大小不能超过 2MB!\');\r\n                    return;\r\n                }\r\n            }\r\n        }\r\n    };\r\n</script>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
