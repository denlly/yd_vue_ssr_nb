
requirejs.config({
            // 默认从js/lib加载所有的module ID
            baseUrl: '/scripts',
            paths: {
                jquery: 'https://cdn.bootcss.com/jquery/3.2.1/jquery.min'
            }
        });

        // 启动main operate
        requirejs(['jquery','Operator'],
                function ($,operator) {
                //formDom,clickDom,seccess,fail
                  var addope = new operator.AddOperater(
                    $("#form_main"),
                    $("#btn_sumbit"),
                    (data)=>{
                        console.log(data);
                    },
                    (data)=>{
                        console.log(data);
                    });
                    console.dir(addope);
                }
        );
                    
