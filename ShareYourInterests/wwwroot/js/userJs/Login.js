var vm = new Vue({
    el: '#app',
    vuetify: new Vuetify(),
    data() {
        return {
            showPassword: false,
            userAccount: '',
            userPassword: '',
            showAlert: false,
            rules: {
                required: value => !!value || 'Required.',
                min: v => v.length >= 8 || 'Min 8 characters'
            },
        }
    },
    methods:
    {
        Login() {
            this.$http.post('/Login/UserLogin', { UserAccount: this.userAccount, UserPassword: this.userPassword })
                .then(
                    function (result) {
                        if (result.body.code == 200) {
                            window.location.href = "Home/Index";
                        } else {
                            this.showAlert = true;
                            setTimeout(function () { vm.showAlert = false }, 3000);
                        }
                    });
        }

    },
    computed:
    {
        isButtonDisabled() {
            return this.userPassword.length < 8 || this.userAccount.length === 0;
        }
    }
});


// // 初始化验证码  弹出式
$('#mpanel2').slideVerify({
    baseUrl: 'https://captcha.anji-plus.com/captcha-api',  //服务器请求地址, 默认地址为安吉服务器;
    mode: 'pop',     //展示模式
    containerId: 'btn',//pop模式 必填 被点击之后出现行为验证码的元素id
    imgSize: {       //图片的大小对象,有默认值{ width: '310px',height: '155px'},可省略
        width: '400px',
        height: '200px',
    },
    barSize: {          //下方滑块的大小对象,有默认值{ width: '310px',height: '50px'},可省略
        width: '400px',
        height: '40px',
    },
    beforeCheck: function () {  //检验参数合法性的函数  mode ="pop"有效
        var flag = true;
        //实现: 参数合法性的判断逻辑, 返回一个boolean值
        return flag;
    },
    ready: function () { },  //加载完毕的回调
    success: function (params) { //成功的回调
        // params为返回的二次验证参数 需要在接下来的实现逻辑回传服务器
        // 例如: login($.extend({}, params)) 
        vm.Login();
    },
    error: function () { }        //失败的回调
});
