<template>
  <div id="app">
      <navbar></navbar>
    <router-view/>
  </div>
</template>

<script>
    import Navbar from './components/Navbar'
    export default {
        name: 'App',
        data() {
            return {

            }
        },
        components: {
            Navbar
        },
        mounted() {
            this.$store.dispatch('authenticate')
        },
        methods: {},
        computed: {
            user() {
                return this.$store.state.user
            }
        }
    }
</script>

<style>
    #app {
        font-family: 'Avenir', Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        margin-top: 60px;
    }
</style>