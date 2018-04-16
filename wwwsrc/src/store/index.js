import vue from 'vue'
import vuex from 'vuex'
import axios from 'axios'
import router from '../router'



let api = axios.create({
    baseURL: base + 'api/',
    timeout: 20000,
    withCredentials: true
})

let auth = axios.create({
    baseURL: base,
    timeout: 5000,
    withCredentials: true
})

vue.use(vuex)

var store = new vuex.Store({
    state: {
        error: {},
        user: {},
        mines: {},
        vaults: [],
        keeps: [],
        userKeeps: [],
        activeVault: {},
        activeKeep: {}
    },

    mutations: {
        handleError(state, err) {
            state.error = err
        },

        setUser(state, data) {
            state.user = data
        },

        setMines(state, data) {
            state.mine = data
        },

        setVaults(state, data) {
            state.vaults = data
        },

        setKeeps(state, data) {
            state.keeps = data
        },

        setUserKeeps(state, data) {
            state.userKeeps = data
        },

        setActiveVault(state, data) {
            state.activeVault = data
        },

        setActiveKeep(state, data) {
            state.acvtiveKeep = data
        }
    },

    actions: {

    }
})

export default store