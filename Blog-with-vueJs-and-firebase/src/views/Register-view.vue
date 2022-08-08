<template>
  <div class="form-wrap">
    <form class="register">
        <p class="login-register">
            Вече имате акаунт?
            <router-link class="router-link" :to="{ name: 'Login' }">Вход</router-link>
        </p>
        <h2>Създаване на акаунт</h2>
        <div class="inputs">
            <div class="input">
                <input type="text" placeholder="First Name" v-model="firstName">
                <font-awesome-icon class="icon" icon="fa-solid fa-user" />
            </div>
            <div class="input">
                <input type="text" placeholder="Last Name" v-model="lastName">
                <font-awesome-icon class="icon" icon="fa-solid fa-user" />
            </div>
            <div class="input">
                <input type="text" placeholder="Username" v-model="userName">
                <font-awesome-icon class="icon" icon="fa-solid fa-user" />
            </div>
            <div class="input">
                <input type="text" placeholder="Email" v-model="email">
                <font-awesome-icon class="icon" icon="fa-solid fa-envelope" />
            </div>
            <div class="input">
                <input type="password" placeholder="Password" v-model="password">
                <font-awesome-icon class="icon" icon="fa-solid fa-key" />
            </div>
            <div v-show="error" class="error">{{ errorMsg }}</div>
        </div>

        <button @click.prevent="register">Регистрация</button>
        <div class="angle"></div>
    </form>
    <div class="background"></div>
  </div>
</template>

<script>
import { library } from '@fortawesome/fontawesome-svg-core';
import { faEnvelope, faKey, faUser } from '@fortawesome/free-solid-svg-icons';
library.add([faEnvelope, faKey, faUser]);

import firebase from 'firebase/app';
import 'firebase/auth';
import db from '../firebase/firebaseInit.js';

export default {
    name: 'Register',
    data() {
        return {
            firstName: '',
            lastName: '',
            userName: '',
            email: '',
            password: '',
            error: false,
            errorMsg: ''
        };
    },
    methods: {
        async register() {
            if(this.email != '' && this.password != '' && this.firstName != '' && this.lastName != '' && this.userName != '') {
                this.error = false;
                this.errorMsg = '';

                const firebaseAuth = await firebase.auth();
                const createUser = await firebaseAuth.createUserWithEmailAndPassword(this.email, this.password);
                const result = await createUser;
                const dataBase = db.collection('users').doc(result.user.uid);
                
                await dataBase.set({
                    firstName: this.firstName,
                    lastName: this.lastName,
                    username: this.userName,
                    email: this.email
                });

                this.$router.push({ name: 'Home' });
                
                return;
            }

            this.error = true;
            this.errorMsg = 'Моля попълнете всички полета.';
        }
    }
}
</script>

<style lang="scss" scoped>
.register {
    h2 {
        max-width: 350px;
    }
}
</style>