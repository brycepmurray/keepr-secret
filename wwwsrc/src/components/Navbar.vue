<template>
        <div class="container-fluid body">
                <div class="row d-flex justify-content-between navBar">
                  <div class="col-lg-6 col-sm-12 logo">
                    <span class="title">Keepr Secret</span>
                  </div>
                  <div v-if="!user._id" class="col-lg-6 col-sm-12 profileInfo">
                     <form @submit.prevent="login">
                      <input v-model="loginForm.email" type=“email” name=“email” placeholder=email>
                      <input v-model="loginForm.password" type=“text” name=“password” placeholder=password> 
                      <button class="btn btn-success" type="submit">
                          Login
                      </button>
                      </form>
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#registerModal">
                            Register
                        </button>
                        <!-- Modal -->
                        <div class="modal fade" id="registerModal" tabindex="-1" role="dialog" aria-labelledby="registerModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="registerModal">Register</h5>
                          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                              <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <form @submit="createUser">
                                <input v-model="registerForm.username" type=“text” name=“username” placeholder=username id=“”>
                                <input v-model="registerForm.email" type=“text” name=“email” placeholder=bob@bob.com id=“”>
                                <input v-model="registerForm.password" type=“text” name=“password” placeholder=password id=“”>
                                <div class="modal-footer">
                                    <button type="submit" @submit="createUser" class="btn btn-success">Register</button>
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            </div>
            <div v-if="user._id" class="col-lg-6 col-sm-12 postLoginInfo">
                    <h3 class="title userName">{{user.username}}</h3>
                    <button class="btn btn-danger logout">Logout</button>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        mounted() {
            // $(function() {
            //     $('[data-toggle="popover"]').popover()
            // }),
            // $(document).ready(function() {
            //     $("login").click(function() {
            //         $("").replaceWith(`<div class="col-lg-6 col-sm-12 afterLoginInfo">
            //             <img src="http://placehold.it/40x40" alt="user profile image">
            //             <h3>username here</h3>
            //             <button type="button" class="btn btn-danger">Logout</button>
            //             </div>`);
            //     });
            // });
        },
        data() {
            return {
                loginForm: {
                    email: "",
                    password: "",
                },
                registerForm: {
                    username: "",
                    email: "",
                    password: ""
                }
            }
            console.log(registerForm)
        },
        computed: {
            user() {
                return this.$store.state.user
            }
        },
        methods: {
            createUser() {
                console.log("Am I Here?", this.registerForm)
                this.$store.dispatch('createUser', this.registerForm)
            },
            login() {
                this.$store.dispatch('login', this.loginForm)
            },
            logout() {
                swal({
                    title: 'Are you sure?',
                    type: 'warning',
                    showCancelButton: true,
                    cancelButtonColor: '#d33',
                    confirmButtonColor: '#3085d6',
                    cancelButtonText: "No, I'm not sure",
                    confirmButtonText: "Yes, I'm sure",
                    cancelButtonClass: 'btn btn-danger',
                    confirmButtonClass: 'btn btn-success',
                    buttonsStyling: false,
                    reverseButtons: true
                }).then((result) => {
                    if (result.value) {
                        swal(
                            "",
                            "You've been logged out.",
                            'success'
                        )
                        this.$store.dispatch('logout')
                    } else if (result.dismiss === 'cancel') {
                        return
                    }
                })
            },
        },
    }
</script>

<style scoped>

</style>