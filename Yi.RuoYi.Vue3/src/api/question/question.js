import request from '@/utils/request'
/* 以下为api的模板，通用的crud，将以下变量替换即可：
@model@ : 实体模型
*/
// 分页查询
export function listData(query) {
  return request({
    url: '/question',
    method: 'get',
    params: query
  })
}

// id查询
export function getData(id) {
  return request({
    url: `/question/${id}`,
    method: 'get'
  })
}

// 新增
export function addData(data) {
  return request({
    url: '/question',
    method: 'post',
    data: data
  })
}

// 修改
export function updateData(id,data) {
  return request({
    url: `/question/${id}`,
    method: 'put',
    data: data
  })
}

// 删除
export function delData(ids) {
  return request({
    url: `/question`,
    method: 'delete',
    params:{id:ids}
  })
}

// 导出角色
export function getExportExcel(query) {
  
    return download('/question/export-excel',query,'导出数据.xlsx')
  }