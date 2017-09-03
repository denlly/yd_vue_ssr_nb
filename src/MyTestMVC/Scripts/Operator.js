
define(["jquery"],function($){
    class baseOperate{
        constructor(formDom,clickDom,seccess,fail){
             this._urls = [];
             this._formDom = formDom;
             this._urls.push(formDom.action)
             this._clickDom = clickDom ;
             this._doseccess = seccess;
             this._fail = fail;

             this._clickDom.on("click",()=>{
                this.sending(this._formDom.attr("action"),formDom.serialize());
                return false;
             });

        };

        sending (url,data){
            console.dir(data);
            console.dir(url);
            return $.ajax({
                url,
                data,
                dataType: 'json',
                type: 'post',
                seccess:(result)=>{
                    alert(result);
                }
            });

        };
    }

    class AddOperater extends baseOperate{
        constructor (formDom,clickDom,seccess,fail){
            super(formDom,clickDom,seccess,fail);
        }

    }

    return {
        AddOperater,
    }

})
