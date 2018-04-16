import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import Vault from '@/components/Vault'
import Keep from '@/components/Keep'
import Main from '@/components/Main'

Vue.use(Router)

export default new Router({
    routes: [{
            path: '/',
            name: 'Home',
            component: Home
        },
        {
            path: '/vaults',
            name: 'Vaults',
            component: Vault
        },
        {
            path: '/keeps',
            name: 'Keeps',
            component: Keep
        },
        {
            path: '/main',
            name: 'Main',
            component: Main
        }
    ]
})