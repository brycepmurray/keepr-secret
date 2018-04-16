<template>
<div class="Login">
    <header>
        <h2 class="keepr">Keepr-Secret</h2>
    </header>
    <div class="panel" v-if="loginFormActive">
            <div class="panel-body">
                <form type="submit" @submit.prevent="submitLogin">
                    <div class="form-group">
                        <label for="email">Email:</label>
                        <input type="email" class="form-control" placeholder="bob@bob.com" v-model="login.email" required>
                    </div>
                    <div class="form-group">
                        <label for="password">Password:</label>
                        <input type="password" class="form-control" placeholder="123badpassword" v-model="login.password" required>
                    </div>
                    <div class="form-group">
                        <button type="submit" class="btn">Login</button>
                    </div>
                    <a class="toggle-link cursor" @click="toggleFormState">Sign Up Here</a>
                </form>
            </div>
        </div>
        <div class="panel" v-else>
                <div class="panel-body">
                    <form type="submit" @submit.prevent="submitRegister">
                        <div class="form-group">
                            <label for="name">Username:</label>
                            <input type="text" class="form-control" placeholder="username" v-model="register.username" required>
                        </div>
                        <div class="form-group">
                            <label for="email">Email:</label>
                            <input type="email" class="form-control" placeholder="bob@bob.com" v-model="register.email" required>
                        </div>
                        <div class="form-group">
                            <label for="password">Password:</label>
                            <input type="password" class="form-control" placeholder="password" v-model="register.password" required>
                        </div>
                        <div class="form-group">
                            <label for="image">Profile Image:</label>
                            <input type="text" class="form-control" placeholder="placehold.it/70x70" v-model="register.imageUrl">
                        </div>
                        <div class="form-group">
                            <button type="submit" class="btn">Register</button>
                        </div>
                        <a class="toggle-link cursor" @click="toggleFormState">Already Have an Account? Login now!</a>
                    </form>
                </div>
        </div>
</div>
</template>

<script>
    import Vue from 'vue'

    export default {
        data() {
            return {
                login: {
                    email: '',
                    password: ''
                },
                register: {
                    username: '',
                    email: '',
                    password: '',
                    imageUrl: ''
                },
                loginFormActive: true
            }
        },
        computed: {
            error() {
                return this.$store.state.error.message
            }
        }
    }
</script>

<style scoped>

</style>