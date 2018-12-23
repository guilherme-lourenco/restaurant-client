import { http } from './config';

export default{
    getOrder:(input)=>{
        return http.get('Order/GetOrder/'+input)
    
    }
};