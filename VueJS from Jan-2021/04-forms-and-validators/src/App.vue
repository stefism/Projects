<template>
  <div class="container d-flex pt-5">
    <form class="flex-fill" @submit.prevent="handleFormSubmit">
      <div class="row">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3">
          <h1>Registration</h1>
          <hr />
  
          <div class="form-group">
            <label for="email">Email</label>
            <input 
              v-model.lazy.trim="$v.formData.email.$model"
              type="text" 
              id="email" 
              class="form-control"
            />
              <!-- v-model.lazy - това е модифайер. По подразбиране v-model тригерва инпунт евент. Тоест при всяко натискане на клавиш, променливата прикачена към евента се обновява. Ако искаме да променим v-model да не се закача към input event-а, а към change евента, използваме .lazy. Има още два модифиера на v-model - .number - автоматично опитва да кастне данните към число. .trim - премахва интервалите, които са отпред и отзад на въведените данни. -->
              <!-- Когато използваме Vuelidate библиотеката, трябва горе на v-model да пишем байндването към него - "$v.formData.email.$model" -->
            <p>{{formData.email}}</p>
            
            <Validator forField="email" :vData="$v.formData"/>
          </div>

          <EmailInput 
            :email="compData.email"
            @on-input="compData.email = $event"
          />
          <p>{{compData.email}}</p>
          <!-- Подаваме имейла като пропс, който ще се запише във велюто на инпут полето на EmailInput. Понеже тук подаваме освен евента и event.target.value, което всъщност е това, което ще напишем в инпут полето на EmailInput и понеже сме подали като евент, евента input, всеки път като напишем нещо в инпут полето, с реда @onInput="compData.email = $event", записваме обратно в променливата compData.email, това, което е дошло от инпут полето на EmailInput елемента. $event в случая ще е event.target.value, което сме подали от инпут полето на EmailInput елемента. -->

          <EmailInputVModel v-model="compData.emailVModel" />
          <p>EmailInputVModel test: {{compData.emailVModel}}</p>
          
          <div class="form-group">
            <label for="password">Password</label>
            <input
              v-model.lazy.trim="$v.formData.password.$model" 
              type="password" 
              id="password" 
              class="form-control"/>

              <Validator forField="password" :vData="$v.formData"/>
          </div>

          <div class="form-group">
            <label for="repass">Re enter Password</label>
            <input
              v-model.lazy.trim="$v.formData.repass.$model" 
              type="password" 
              id="repass" 
              class="form-control"/>

              <Validator forField="repass" :vData="$v.formData"/>
          </div>

          <div class="form-group">
            <label for="age">Age</label>
            <input 
              v-model.number="$v.formData.age.$model"
              type="number" 
              id="age" 
              class="form-control"/>

              <Validator forField="age" :vData="$v.formData"/>
          </div>

          <!---->
        </div>
      </div>
      <div class="row">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 form-group">
          <label for="description">Description</label>
          <br />
          <textarea 
            v-model.lazy="$v.formData.description.$model" 
            id="description" 
            rows="5" 
            class="form-control">
          </textarea>

          <Validator forField="description" :vData="$v.formData"/>
        </div>
      </div>
      <div class="row">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3">
          <div class="form-group">
            <h3>Skill Set</h3>
            <label v-for="skill in skillSets" :key="skill.id" :for="skill.id">
              <input
                v-model="formData.skillSet"
                type="checkbox" 
                :id="skill.id" 
                :value="skill.name"/>
              {{ skill.name }}
            </label>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 form-group">
          <label v-for="gender in genders" :key="gender.id" :for="gender.id">
            <input 
              v-model="formData.gender" 
              type="radio" 
              :id="gender.id" 
              :value="gender.name"/>
            {{ gender.name }}
          </label>
        </div>
      </div>
      <div class="row">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 from-group">
          <label for="country">Country</label>
          <select v-model="formData.country" id="country" class="form-control">
            <option v-for="(country, index) in countries" 
              :key="index">
              {{ country }}
            </option>
          </select>
        </div>
      </div>
      <hr />
      <div class="row">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3">
          <button :disabled="isSubmitDisabled" type="submit" class="btn btn-primary">Submit!</button>
        </div>
      </div>
    </form>
    <form class="flex-fill" v-if="isSubmitted">
      <div class="row">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3">
          <div class="panel panel-default">
            <div class="panel-heading">
              <h4 class="panel-heading">Your Data</h4>
            </div>
            <div class="panel-body">
              <p>Mail: {{ formData.email }}</p>
              <p>Password: {{ formData.password }}</p>
              <p>Age: {{ formData.age }}</p>
              <p>Description: {{ formData.description }}</p>
              <p><strong>Skill Set?</strong></p>
              <ul>
                <li v-for="(skill, index) in formData.skillSet" :key="index">
                  {{ skill }}
                </li>
              </ul>
              <p>Gender: {{ formData.gender }}</p>
              <p>Country: {{ formData.country }}</p>
            </div>
          </div>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
import resources from './assets/resources.json';

import EmailInput from './components/Email-input.vue';
import EmailInputVModel from './components/Email-inputwith-v-model.vue';
import Validator from './components/Field-validator.vue';

import { required, email, minLength, maxLength, 
          alphaNum, minValue, sameAs } from 'vuelidate/lib/validators';

export default {
  name: 'App',
  components: {
    EmailInput, EmailInputVModel, Validator
  },
  data() {
    return {
      isSubmitted: false,
      isLoading: false,
      genders: resources.genders,
      countries: resources.countries,
      formData: {
        email: '',
        password: '',
        repass: '',
        age: null, //Age is be a number. Automatically cast by v-model.number property.
        description: '',
        skillSet: [], // Когато имаме чек бокс, променливата трябва да е масив.
        gender: '',
        country: 'Bulgaria'
      },
      compData: {
        email: '',
        emailVModel: ''
      }
    }
  },
  validations: { //Това validations идва от библиотеката Vuelidate да валидация, която сме добавили глобално във Vue през main.js файла.
    formData: {
        email: { required, email },
        password: { 
          required, 
          minLength: minLength(4), 
          maxLength: maxLength(16), 
          alphaNum 
          },
        repass: {
          sameAs: sameAs('password')
        },
        age: {
          required,
          minValue: minValue(18)
          }, 
        description: { 
          required,
          minLength: minLength(10),
          maxLength: maxLength(100) 
          },
      }
  },
  computed: {
    skillSets() {
      return resources.skillSets;
    },
    isSubmitDisabled() {
      return this.$v.$invalid;
    }
  },
  methods: {
    async handleFormSubmit() {
      this.isSubmitted = true;
      this.isLoading = true;
      this.$v.$touch(); //Казва на Vuelidate да направи проверка на всички обекти, дали са валидни.

      // try {
      //   const responce = await fetch('/form-submit', {
      //     method: 'post',
      //     body: JSON.stringify(this.formData)
      //   });

      //   if(responce.ok == false) {
      //     throw new Error('Server is not responce or endpoint is not valid.')
      //   }
      // } catch (error) {
      //   console.log(error);
      // }

      console.log('Is data from Vuelidate invalid: ', this.$v.$invalid);
      console.log('vuelidate: ', this.$v.formData);
      this.isLoading = false; //Слагаме тази променлива за да може докато се чака за асинхронната заявка, горе да показваме някакъв спинър или нещо такова.
    }
  }
}
</script>

<style>
  @import url("https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css");
</style>
