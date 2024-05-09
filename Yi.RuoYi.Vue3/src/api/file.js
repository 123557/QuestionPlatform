import request from '@/utils/request'

export function
   upload(data){
    return request({
        url: `/file`,
        headers:{"Content-Type": "application/x-www-form-urlencoded; charset=UTF-8"},
        method: 'POST',
        data:data
      });
} 
export function
   uploadlist(data){
    return request({
        url: `/filelist`,
        headers:{"Content-Type": "application/x-www-form-urlencoded; charset=UTF-8"},
        method: 'POST',
        data:data,
      });
} 
export function
   getPicturePathlist(id){
    return request({
        url: `/getPicturepath`,
        method: 'get',
        params: {questionid:id}
      });
} 

export function
   uploadpic(id){
    return request({
        url: `/picturefile`,
        headers:{"Content-Type": "application/x-www-form-urlencoded; charset=UTF-8"},
        method: 'get',
        params: {code:id}
      });
} 
