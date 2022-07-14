<template>
  <div class="reset-password">
    <Modal 
        v-if="modalActive" 
        @close-modal="closeModal" 
        :modalMessage="modalMessage"
    />
    <Loading v-if="loading" />
    <div class="form-wrap">
        <form class="reset">
            <p class="login-register">
                Обратно към 
                <router-link class="router-link" :to="{ name: 'Login' }">Вход</router-link>
            </p>
            <h2>Нулиране на паролата</h2>
            <p>Забравихте си паролата? Въведете вашия и-мейл за нулиране.</p>
            <div class="inputs">
                <div class="input">
                    <input type="text" placeholder="Email" v-model="email">
                    <email class="icon" />
                </div>
            </div>
            <button @click.prevent="resetPassword">Нулиране</button>
            <div class="angle"></div>
        </form>
        <div class="background"></div>
    </div>
  </div>
</template>

<script>
import email from '../assets/Icons/envelope-regular.svg';
import Modal from '../components/Modal-comp.vue';
import Loading from '../components/Loading-comp.vue';

import firebase from 'firebase/app';
import 'firebase/auth';

export default {
    name: 'ForgotPassword',
    data() {
        return {
            email: '',
            modalActive: false,
            modalMessage: '',
            loading: null
        }
    },
    components: { email, Modal, Loading },
    methods: {
        resetPassword() {
            this.loading = true;
            
            firebase
                .auth()
                .sendPasswordResetEmail(this.email)
                .then(() => {
                    this.modalMessage = 'Ако имате регистриран акаунт, ще получите поща.';
                    this.loading = false;
                    this.modalActive = true;
                })
                .catch((err) => {
                    this.modalMessage = err.message;
                    this.loading = false;
                    this.modalActive = true;
                });
        },
        closeModal() {
            this.modalActive = !this.modalActive;
            this.email = '';
        }
    }
}
</script>

<style lang="scss" scoped>
.reset-password {
    position: relative;
    .form-wrap {
        .reset {
            h2 {
                margin-bottom: 8px;
            }
            p {
                text-align: center;
                margin-bottom: 32px;
            }
        }
    }
}
</style>