
<template>

    <div class="app-container">
        <!-- <div>
该文件为通用Crud模板文件，按照规范只需要 替换以下变量即可，
@Name@ ： 实体中文名称
@per:per@ ：crud权限编码
@api@ : api文件路径,code/tableApi
    </div> -->
        <el-form :model="queryParams" ref="queryRef" :inline="true" v-show="showSearch" label-width="100px">
            <el-form-item label="问题点标题" prop="title">
                <el-input v-model="queryParams.title" placeholder="请输入问题点标题" clearable style="width: 240px"
                    @keyup.enter="handleQuery" />
            </el-form-item>
            <el-form-item label="问题点内容" prop="description">
                <el-input v-model="queryParams.description" placeholder="请输入问题点内容" clearable style="width: 240px"
                    @keyup.enter="handleQuery" />
            </el-form-item>
            <el-form-item label="项目" prop="project">
                <!-- <el-input v-model="queryParams.project" placeholder="请输入问题点所属项目" clearable style="width: 240px"
                    @keyup.enter="handleQuery" /> -->
                    <el-select
                        v-model="queryParams.project"
                        placeholder="请输入问题点所属项目"
                        clearable
                        style="width: 240px"
                        >
                    <el-option
                        v-for="dict in question_project_type"
                        :key="dict.value"
                        :label="dict.label"
                        :value="dict.value"
                    />
                </el-select>
            </el-form-item>
            <!-- <el-form-item label="状态" prop="status">
                <el-input v-model="queryParams.status" placeholder="请输入问题点状态" clearable style="width: 240px"
                    @keyup.enter="handleQuery" />
            </el-form-item> -->
            <el-form-item label="状态" prop="state">
                <el-select
                    v-model="queryParams.state"
                    placeholder="请选择问题点状态"
                    clearable
                    style="width: 240px"
                        >
                    <el-option
                        v-for="dict in status_type"
                        :key="dict.value"
                        :label="dict.label"
                        :value="dict.value"
                    />
                </el-select>
            </el-form-item>
            <el-form-item label="分类" prop="category">
                <!-- <el-input v-model="queryParams.category" placeholder="请输入问题点分类" clearable style="width: 240px"
                    @keyup.enter="handleQuery" /> -->
                    <el-select
                        v-model="queryParams.state"
                        placeholder="请选择问题点分类"
                        clearable
                        style="width: 240px"
                            >
                            <el-option
                                v-for="dict in question_category_type"
                                :key="dict.value"
                                :label="dict.label"
                                :value="dict.value"
                            />
                    </el-select>
            </el-form-item>
            <el-form-item label="优先级" prop="priority">
                <!-- <el-input v-model="queryParams.priority" placeholder="请输入问题点优先级" clearable style="width: 240px"
                    @keyup.enter="handleQuery" /> -->
                    <el-select
                        v-model="queryParams.state"
                        placeholder="请选择问题点优先级"
                        clearable
                        style="width: 240px"
                            >
                            <el-option
                                v-for="dict in priority_type"
                                :key="dict.value"
                                :label="dict.label"
                                :value="dict.value"
                            />
                    </el-select>
            </el-form-item>
            <el-form-item label="影响度" prop="impact">
                <!-- <el-input v-model="queryParams.priority" placeholder="请输入问题点优先级" clearable style="width: 240px"
                    @keyup.enter="handleQuery" /> -->
                    <el-select
                        v-model="queryParams.impact"
                        placeholder="请选择问题点优先级"
                        clearable
                        style="width: 240px"
                            >
                            <el-option
                                v-for="dict in impact_type"
                                :key="dict.value"
                                :label="dict.label"
                                :value="dict.value"
                            />
                    </el-select>
            </el-form-item>
            
            <!-- <el-form-item label="处理人" prop="solve_user">
                <el-input v-model="queryParams.solve_user" placeholder="请输入处理人" clearable style="width: 240px"
                    @keyup.enter="handleQuery" />
            </el-form-item> -->
            <!-- <el-form-item label="状态" prop="isDeleted">
            <el-select
              v-model="queryParams.isDeleted"
              placeholder="状态"
              clearable
              style="width: 240px"
            >
              <el-option
                v-for="dict in sys_normal_disable"
                :key="dict.value"
                :label="dict.label"
                :value="dict.value"
              />
            </el-select>
          </el-form-item> -->
            <el-form-item label="创建时间" style="width: 308px">
            <el-date-picker
              v-model="dateRange"
              value-format="YYYY-MM-DD"
              type="daterange"
              range-separator="-"
              start-placeholder="开始日期"
              end-placeholder="结束日期"
            ></el-date-picker>
          </el-form-item>
            <el-form-item>
                <el-button type="primary" icon="Search" @click="handleQuery">搜索</el-button>
                <el-button icon="Refresh" @click="resetQuery">重置</el-button>
            </el-form-item>
        </el-form>

        <el-row :gutter="10" class="mb8">
            <el-col :span="1.5">
                <el-button type="primary" plain icon="Plus" @click="handleAdd" v-hasPermi="['question:questiones:add']">新增</el-button>
            </el-col>
            <el-col :span="1.5">
                <el-button type="success" plain icon="Edit" :disabled="single" @click="handleUpdate"
                    v-hasPermi="['question:questiones:edit']">修改</el-button>
            </el-col>
            <el-col :span="1.5">
                <el-button type="danger" plain icon="Delete" :disabled="multiple" @click="handleDelete"
                    v-hasPermi="['question:questiones:remove']">删除</el-button>
            </el-col>
            <el-col :span="1.5">
                <el-button type="warning" plain icon="Download" @click="handleExport"
                    v-hasPermi="['question:questiones:export']">导出</el-button>
            </el-col>
            <right-toolbar v-model:showSearch="showSearch" @queryTable="getList"></right-toolbar>
        </el-row>

        <el-table v-loading="loading" :data="dataList" @selection-change="handleSelectionChange">
            <el-table-column type="selection" width="55" align="center" />

            <!-----------------------这里开始就是数据表单的全部列------------------------>
            <el-table-column label="标题" align="center" prop="title" />
            <el-table-column label="所属项目" align="center" prop="project" :show-overflow-tooltip="true" />
            <el-table-column label="状态" align="center" prop="status" :show-overflow-tooltip="true" />
            <el-table-column label="影响" align="center" prop="impact" :show-overflow-tooltip="true" />
            <el-table-column label="优先级" align="center" prop="priority" :show-overflow-tooltip="true" />
            <!-- <el-table-column label="详情" align="center" prop="description" :show-overflow-tooltip="true" /> -->
            <!-- <el-table-column label="处理人" align="center" prop="solve_user" :show-overflow-tooltip="true" /> -->
            <el-table-column label="创建时间" align="center" prop="creationTime" :show-overflow-tooltip="true" />
            <!-- <el-table-column label="状态" align="center" prop="isDeleted">
            <template #default="scope">
              <dict-tag
                :options="sys_normal_disable"
                :value="scope.row.isDeleted"
              />
            </template>
          </el-table-column> -->
            <!-- <el-table-column
            label="备注"
            align="center"
            prop="remark"
            :show-overflow-tooltip="true"
          />
          <el-table-column
            label="创建时间"
            align="center"
            prop="creationTime"
            width="180"
          >
            <template #default="scope">
              <span>{{ parseTime(scope.row.creationTime) }}</span>
            </template>
          </el-table-column> -->
            <el-table-column label="操作" align="center" class-name="small-padding fixed-width" >
                <template #default="scope">
                    <el-tooltip content="详情" placement="top" v-if="scope.row.userName != 'cc'">
                    <el-button type="text" icon="Document" @click="handleDescription(scope.row)"></el-button>
                    </el-tooltip>
                    <el-tooltip content="修改" placement="top" v-if="scope.row.userName != 'cc'">
                    <el-button type="text" icon="Edit" @click="handleUpdate(scope.row)"
                        v-hasPermi="['question:questiones:edit']"></el-button>
                    </el-tooltip>
                    <el-tooltip content="删除" placement="top" v-if="scope.row.userName != 'cc'">
                    <el-button type="text" icon="Delete" @click="handleDelete(scope.row)"
                        v-hasPermi="['question:questiones:remove']"></el-button>
                    </el-tooltip>
                </template>
            </el-table-column>
        </el-table>
        <pagination v-show="total > 0" :total="Number(total)" v-model:page="queryParams.skipCount"
            v-model:limit="queryParams.maxResultCount" @pagination="getList" />

        <!-- ---------------------这里是新增和更新的对话框--------------------- -->
        <el-dialog :title="title" v-model="open" width="800px" append-to-body>
            <el-form ref="dataRef" :model="form" :rules="rules" label-width="100px">
                <el-form-item label="标题" prop="title">
                    <el-input v-model="form.title" placeholder="请输入标题" />
                </el-form-item>
                <el-form-item label="项目" prop="project">
                    <el-input v-model="form.project" placeholder="请输入所属项目" />
                </el-form-item>
                <!-- <el-form-item label="状态" prop="status">
                    <el-input v-model="form.status" placeholder="请输入状态" />
                </el-form-item> -->
                <el-form-item label="状态" prop="status">
                    <el-select
                    v-model="form.status"
                    placeholder="请选择问题点状态"
                    clearable
                    style="width: 240px"
                    >
                    <el-option
                        v-for="dict in status_type"
                        :key="dict.value"
                        :label="dict.label"
                        :value="dict.value"
                    />
                    </el-select>
                </el-form-item>
                <el-form-item label="类别" prop="category">
                    <el-input v-model="form.category" placeholder="请输入类别" />
                </el-form-item>
                <el-form-item label="影响" prop="impact">
                    <el-input v-model="form.impact" placeholder="请输入影响" />
                </el-form-item>
                <el-form-item label="优先级" prop="priority">
                    <el-input v-model="form.priority" placeholder="请输入优先级" />
                </el-form-item>
                <el-form-item label="具体内容" prop="description">
                    <el-input v-model="form.description" placeholder="请输入具体内容"  type="textarea"/>
                </el-form-item>
                <el-form-item label="图片" prop="picturelist">
                    <el-upload
                    class="upload-demo"
                    ref="upload"
                    accept=".png,.jpg"
                    action="#"
                    :limit="5"
                    multiple
                    :on-exceed="onExceed"
                    :file-list="fileList"
                    :on-change="handlChange"
                    :auto-upload="false">
                        <el-button type="primary">上传文件</el-button>
                        <template #tip>
                        <div class="el-upload__tip">
                            建议尺寸大小为192*128,大小不超过2M,最多上传五个图片
                        </div>
                        </template>
                    </el-upload>
                    
                </el-form-item>
                
                <!-- <el-form-item label="处理人" prop="solve_user">
                    <el-input v-model="form.solve_user" placeholder="请输入处理人" />
                </el-form-item> -->
                <!-- <el-form-item label="状态" prop="isDeleted">
              <el-radio-group v-model="form.isDeleted">
                <el-radio
                  v-for="dict in sys_normal_disable"
                  :key="dict.value"
                  :label="JSON.parse(dict.value)"
                  >{{ dict.label }}</el-radio
                >
              </el-radio-group>
            </el-form-item> -->
            </el-form>
            <template #footer>
                <div class="dialog-footer">
                    <el-button type="primary" @click="submitForm">确 定</el-button>
                    <el-button @click="cancel">取 消</el-button>
                </div>
            </template>
        </el-dialog>

        <!-- ---------------------这里是详情的对话框--------------------- -->
        <el-dialog :title="title" v-model="descopen" width="800px" append-to-body>
            <el-descriptions :column="1">
                <el-descriptions-item label="标题">{{questionList.title}}</el-descriptions-item>
                <el-descriptions-item label="所属项目">{{questionList.project}}</el-descriptions-item>
                <el-descriptions-item label="状态">{{questionList.status}}</el-descriptions-item>
                <el-descriptions-item label="类别">{{questionList.category}}</el-descriptions-item>
                <el-descriptions-item label="影响">{{questionList.impact}}</el-descriptions-item>
                <el-descriptions-item label="优先级">{{questionList.priority}}</el-descriptions-item>
                <el-descriptions-item label="详情">{{questionList.description}}</el-descriptions-item>
                <el-descriptions-item label="创建时间">{{questionList.creationTime}}</el-descriptions-item>
                <el-descriptions-item label="图片">
                <div class="demo-image__preview">
                    <el-image
                    v-for="(item,index ) in uploadPictureList"
                    :item="item"
                    :index="index"
                    :key="item.id"
                    style="width: 100px; height: 100px"
                    :src="item"
                    :zoom-rate="1.2"
                    :max-scale="7"
                    :min-scale="0.2"
                    :preview-src-list="[item]"
                    fit="cover"
                    />
                </div>
                </el-descriptions-item>
            </el-descriptions>
        </el-dialog>
    </div>
</template>
    
<script setup name="Question">
import { getInfo } from "@/api/login.js"
import {
    listData,
    getData,
    delData,
    addData,
    updateData,
} from "@/api/question/question";
import { ref } from "@vue/reactivity";
import { uploadlist,getPicturePathlist, uploadpic} from "@/api/file";
const userInfo =ref([]) ;
getInfo().then((response)=>{ 
    //userInfo = responses
    //console.log(response.data.user);
    userInfo.value=response.data.user;
});

const router = useRouter();
const { proxy } = getCurrentInstance();
const { status_type } = proxy.useDict("status_type");
const { question_project_type } = proxy.useDict("question_project_type");
const { impact_type } = proxy.useDict("impact_type");
const { question_category_type } = proxy.useDict("question_category_type");
const { priority_type } = proxy.useDict("priority_type");

const picture_url = import.meta.env.VITE_APP_BASE_URL
const dataList = ref([]);
const questionList = ref([]);
const showPictureList = ref([])
const uploadPictureList = ref([])
const open = ref(false);
const descopen = ref(false);
const loading = ref(true);
const showSearch = ref(true);
const ids = ref([]);
const single = ref(true);
const multiple = ref(true);
const total = ref(0);
const title = ref("");
const dateRange = ref([]);
const fileList = ref([]);
const data = reactive({
    form: {
    },
    queryParams: {
        skipCount: 1,
        maxResultCount: 10,
        title: undefined,
        description: undefined,
        project: undefined,
        status: undefined,
        category: undefined,
        impact: undefined,
        priority: undefined,
    },
    rules: {
        title: [{ required: true, message: "标题不能为空", trigger: "blur" }],
        description: [{ required: true, message: "内容不能为空", trigger: "blur" }],
        project: [{ required: true, message: "所属项目不能为空", trigger: "blur" }],
        status: [{ required: true, message: "状态不能为空", trigger: "blur" }],
        category: [{ required: true, message: "类别不能为空", trigger: "blur" }],
        impact: [{ required: true, message: "影响不能为空", trigger: "blur" }],
        priority: [{ required: true, message: "优先级不能为空", trigger: "blur" }],
    },
});


const { queryParams, form, rules } = toRefs(data);

/** 查询列表 */
function getList() {
    loading.value = true;
    listData(proxy.addDateRange(queryParams.value, dateRange.value)).then(
        (response) => {
            dataList.value = response.data.items;
            total.value = response.data.totalCount;
            loading.value = false;
        }
    );
}
/** 取消按钮 */
function cancel() {
    open.value = false;
    reset();
}


/** 表单重置 */
function reset() {
    proxy.resetForm("dataRef");
    proxy.picturelist=[]
    proxy.fileList=[]
}
/** 搜索按钮操作 */
function handleQuery() {
    queryParams.value.skipCount = 1;
    getList();
}
/** 重置按钮操作 */
function resetQuery() {
    dateRange.value = [];
    proxy.resetForm("queryRef");
    handleQuery();
}
/** 详情按钮操作 */
function handleDescription(row) {
    const id = row.id || ids.value;
    getData(id).then((response) => {
        questionList.value = response.data;
        console.log(questionList.value)
        descopen.value = true;
        title.value = "问题点详情";
    });
    getPicturePathlist(row.id).then((response)=>{
        showPictureList.value = response.data;
        //console.log(showPictureList.value[0].id)
        uploadPictureList.value =showPictureList.value.map((item) => picture_url + '/picturefile?code='+item.id)
        console.log(uploadPictureList)
        //console.log(import.meta.env.VITE_APP_BASE_URL+'/picturefile/'+row.id)
    })

    
}
/** 新增按钮操作 */
function handleAdd() {
    reset();
    open.value = true;
    title.value = "添加问题点";
}
/** 多选框选中数据 */
function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.id);
    single.value = selection.length != 1;
    multiple.value = !selection.length;
}
/** 修改按钮操作 */
function handleUpdate(row) {
    reset();
    const id = row.id || ids.value;
    getData(id).then((response) => {
        form.value = response.data;
        open.value = true;
        title.value = "修改问题点";
    });
}
/** 提交按钮 */
function submitForm() {
    //uploadFiles()
    
    //console.log(form.value)
    proxy.$refs["dataRef"].validate((valid) => {
        if (valid) {
            //console.log(form.value);
            if (form.value.id != undefined) {
                updateData(form.value.id, form.value).then((response) => {
                    uploadFiles(response.data.id)
                    proxy.$modal.msgSuccess("修改成功");
                    open.value = false;
                    getList();
                });
            } else {
                addData(form.value).then((response) => {
                    uploadFiles(response.data.id)
                    proxy.$modal.msgSuccess("新增成功");
                    open.value = false;
                    //console.log(response.data.id)

                    

                    getList();
                });
            }
        }
    });
}
/** 删除按钮操作 */
function handleDelete(row) {
    const delIds = row.id || ids.value;
    proxy.$modal
        .confirm('是否确认删除编号为"' + delIds + '"的数据项？')
        .then(function () {
            return delData(delIds);
        })
        .then(() => {
            getList();
            proxy.$modal.msgSuccess("删除成功");
        })
        .catch(() => { });
}
/** 导出按钮操作 */
function handleExport() {
    proxy.download(
    "/question/export-excel",
    {
      ...queryParams.value,
    },
    `role_${new Date().getTime()}.xlsx`
  );
 }



function handlChange(file, files) {
    for (let i = 0; i < files.length; i++) {
        // console.log(files[i].raw.type)
        // console.log(files[i].type)
        // console.log(files[i].size)
        const isJPG = files[i].raw.type === 'image/jpeg';  
        const isPNG = files[i].raw.type === 'image/png';  
        const isLT2M = files[i].size / 1024 / 1024 < 2;
        if (!isJPG && !isPNG) {  
            proxy.$modal.msgError('上传图片只能是 JPG/PNG 格式!');  
            files.splice(i, 1);
        }  
        if (!isLT2M) {  
            proxy.$modal.msgError('上传图片大小不能超过 2MB!');  
            files.splice(i, 1);
        } 
    }
    //console.log(files)
    fileList.value = files;
    //console.log('当前选择文件', files)
}
function onExceed(files, fileList) {
      proxy.$modal.message(`目前只支持上传3个文件， 请删除后再次选择！`, "error");
    }
async function uploadFiles(id) {
        if(fileList.value.length>0)
        {
            const formData = new FormData()
            fileList.value.forEach(item => {
                if (item.raw) {
                    // 确保 item.raw 是文件对象
                    formData.append('file', item.raw) // 正确添加文件对象到 FormData
                }
            })
            // for (let [key, value] of formData.entries()) {
            // 	console.log(`${key}: ${value}`)
            // }
            // 发送包含文件的 FormData 到服务器
            formData.append('questionid',id)
            const response = await uploadlist(formData)
        }
        //console.log(response.data)

}


getList();
</script>

<style scoped>
.demo-image__error .image-slot {
  font-size: 30px;
}
.demo-image__error .image-slot .el-icon {
  font-size: 30px;
}
.demo-image__error .el-image {
  width: 100%;
  height: 200px;
}
</style>