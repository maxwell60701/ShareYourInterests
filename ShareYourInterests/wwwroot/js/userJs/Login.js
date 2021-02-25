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
