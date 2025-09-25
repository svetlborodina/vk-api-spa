import 'jquery'
import 'popper.js'
import 'bootstrap/dist/css/bootstrap.min.css'
import axios from 'axios'
import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router'
import Auth from './components/Auth.vue'
import Groups from './components/Groups.vue'

axios.defaults.baseURL = 'https://localhost:5000';

Vue.config.productionTip = false
Vue.use(VueRouter);

const router = new VueRouter({
    routes: [
        {
            path: '/auth',
            name: 'Авторизация ВКонтакте',
            component: Auth
        },
        {
            path: '/groups',
            name: 'Группы',
            component: Groups
        },
        {
            path: '*',
            redirect: '/auth'
        },
    ]
})

new Vue({
    router,
    render: h => h(App),
}).$mount('#app')



