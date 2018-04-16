<template>
    <div class="login">
        <div class="row">
            <!-- Modal -->
            <div id="loginModal" class="modal fade" role="dialog">
                <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <div class="col-sm-12">
                                <h4>Account</h4>
                            </div>
                        </div>
                        <div class="modal-body">
                            <div v-if="loginForm">
                                <form @submit.prevent="Login">
                                    <div class="form-group">
                                        <input type="text" placeholder="bob@bob.com" v-model="login.email">                                
                                    </div>
                                    <div class="form-group">
                                        <input type="password" placeholder="password" v-model="login.password">
                                    </div>
                                    <div class="form-group">
                                        <button type="submit" class="btn btn-success">Login</button>
                                    </div>
                                </form>
                            </div>
                            <div v-else>
                                <form @submit.prevent="Register">
                                    <div class="form-group">
                                        <input type="text" placeholder="bob@bob.com" v-model="register.email">
                                    </div>
                                    <div class="form-group">
                                        <input type="text" placeholder="username" v-model="register.username">
                                    </div>
                                    <div class="form-group">
                                        <input type="password" placeholder="password" v-model="register.password">
                                    </div>
                                    <div class="form-group">
                                        <button type="submit" class="btn btn-success">Register</button>
                                    </div>
                                </form>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <a class="col-sm-5" v-if="loginForm" @click="toggleLoginForm">Don't have an account? Click to Register.</a>
                            <a class="col-sm-5" v-else @click="toggleLoginForm">Already have an account? Click to Login.</a>
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </template>

<script>
    export default {
        name: "Login",
        data() {
            return {
                loginForm: true,
                login: {
                    email: "",
                    password: ""
                },
                register: {
                    email: "",
                    username: "",
                    password: "",
                    imageUrl: ""
                }
            };
        },
        methods: {
            toggleLoginForm() {
                this.loginForm = !this.loginForm;
            },
            Login() {
                this.$store.dispatch("login", this.login);
                this.login = {
                    email: "",
                    password: ""
                };
            },
            Register() {
                this.$store.dispatch("register", this.register);
                this.register = {
                    email: "",
                    username: "",
                    password: "",
                    imageUrl: "",
                }
            }
        }
    }
</script>

<style scoped>

</style>