<template>
  <div id="app">
    <div class="container">
      <form action="" method="post" @submit.prevent="onCreate">
        <fieldset>
          <h1>Registration form</h1>
          <p class="field field-icon">
            <label for="username">
              <span><i class="fas fa-user"><span v-if="isFormFieldRequired('fullName')">*</span></i></span>
            </label>
            <input type="text" name="username" id="username" 
              class="error" 
              placeholder="Mark Ulrich"
              v-model="$v.formData.fullName.$model"
            >
          </p>

          <!-- if error -->
          <p class="error">Full name field is invalid</p>

          <p class="field field-icon">
            <label for="email">
              <span><i class="fas fa-envelope"><span v-if="isFormFieldRequired('email')">*</span></i></span>
            </label>
            <input type="text" name="email" id="email" 
              placeholder="marg@gmial.com"
              v-model="$v.formData.email.$model"
            >
          </p>

          <p class="field field-icon">
            <label for="tel">
              <span><i class="fas fa-phone"></i></span>
            </label>
            <select name="telPrefix" id="telPrefix" 
              class="tel"
              v-model="$v.formData.phonePrefix.$model"
            >
              <option value="+359">+359</option>
            </select>
            <input type="text" name="tel" id="tel" 
              placeholder="888 888"
              v-model="$v.formData.phone.$model"
            >
          </p>

          <p class="field field-icon">
            <label for="building">
              <span><i class="fas fa-building"></i></span>
            </label>
            <select name="building" id="building" 
              class="building"
              v-model="$v.formData.professions.$model"
            >
              <option value="designer">Designer</option>
              <option value="software-engineer">Software Engineer</option>
              <option value="accountant">Accountant</option>
              <option value="manager">Manager</option>
              <option value="other">Other</option>
            </select>
          </p>

          <p class="field field-icon">
            <label for="password">
              <span><i class="fas fa-lock"></i></span>
            </label>
            <input type="password" name="password" 
              id="password" placeholder="******"
              v-model="$v.formData.password.$model"
            >
          </p>

          <p class="field field-icon">
            <label for="re-password">
              <span><i class="fas fa-lock"></i></span>
            </label>
            <input type="re-password" name="re-password" 
              id="re-password" placeholder="******"
              v-model="$v.formData.confirmPass.$model"
            >
          </p>

          <p><button>Create Account</button></p>

          <p class="text-center">
            Have an account?
            <a href="">Log In</a>
          </p>
        </fieldset>
      </form>
    </div>
  </div>
</template>

<script>
// За инсталиране на Vuelidate:
// 1. npm install vuelidate --save
// 2. Във main.js добавяме тези два реда:
//    import Vuelidate from 'vuelidate';
//    Vue.use(Vuelidate) - преди реда Vue.config.productionTip = false;

import { required, email, numeric, minLength, 
          maxLength, sameAs }  from 'vuelidate/lib/validators';

import { hasTwoNames, isCapitalized, hasOnlyCharactersAndSpace } from './custom-validators/fullName.js';

export default {
  name: 'App',
  data() {
    return {
      formData: {
        fullName: '',
        email: '',
        phone: null,
        phonePrefix: '+359',
        professions: 'designer',
        password: '',
        confirmPass: ''
      }
    }
  },
  methods: {
    onCreate() {
      this.$v.$touch();
      console.log('is invalid: ', this.$v.$invalid);
      console.log('"$v.formData: ', this.$v.formData);
    },
    isFormFieldRequired(field) {
      const hasField = Object.prototype.hasOwnProperty.call(this.$v.formData, field);

      if(!hasField) {
        return false;
      }

      const selectedField = this.$v.formData[field];
      const isFieldRequired = Object.prototype.hasOwnProperty.call(selectedField, 'required');

      return isFieldRequired;
    }
  },
  mounted() {
    const fontAwsomeScript = document.createElement('script');
    fontAwsomeScript.setAttribute('src', 'https://kit.fontawesome.com/3cd69e2433.js');

    document.head.appendChild(fontAwsomeScript);
  },
  components: {
    
  },
  validations: {
    formData: {
        fullName: {
          required,
          isCapitalized, //Къстъм валидатор функция
          hasTwoNames, //Къстъм валидатор функция
          hasOnlyCharactersAndSpace //Къстъм валидатор функция
        },
        email: {required, email},
        phone: {
          required, 
          numeric,
          minLength: minLength(9),
          maxLength: maxLength(9)
          },
        phonePrefix: {required},
        professions: {required},
        password: {
          required,
          minLength: minLength(3),
          maxLength: maxLength(16)
          },
        confirmPass: {
          sameAs: sameAs('password')
        }
      }
  }
}
</script>

<style>
  @import url('./assets/style.css');
</style>
