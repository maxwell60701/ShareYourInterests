new Vue({
    el: '#app',
    vuetify: new Vuetify(),
    data() {
        return {
            showPassword: false,
            userName:'UserName',
            password: 'Password',
            rules: {
                required: value => !!value || 'Required.',
                min: v => v.length >= 8 || 'Min 8 characters'
            },
        }
    },
})