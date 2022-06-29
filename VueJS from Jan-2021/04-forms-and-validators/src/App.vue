<template>
  <div class="container d-flex pt-5">
    <form class="flex-fill">
      <div class="row">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3">
          <h1>Registration</h1>
          <hr />
  
          <div class="form-group">
            <label for="email">Email</label>
            <input 
              v-model.lazy="formData.email"
              type="text" 
              id="email" 
              class="form-control"/>
              <!-- v-model.lazy - това е модифайер. По подразбиране v-model тригерва инпунт евент. Тоест при всяко натискане на клавиш, променливата прикачена към евента се обновява. Ако искаме да променим v-model да не се закача към input event-а, а към change евента, използваме .lazy. Има още два модифиера на v-model - .number - автоматично опитва да кастне данните към число. .trim - премахва всички интервали от въведените данни. -->
          </div>

          <div class="form-group">
            <label for="password">Password</label>
            <input
              v-model="formData.password" 
              type="password" 
              id="password" 
              class="form-control"/>
          </div>

          <div class="form-group">
            <label for="age">Age</label>
            <input 
              v-model="formData.age"
              type="number" 
              id="age" 
              class="form-control"/>
          </div>

          <!---->
        </div>
      </div>
      <div class="row">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 form-group">
          <label for="description">Description</label>
          <br />
          <textarea 
            v-model="formData.description" 
            id="description" 
            rows="5" 
            class="form-control">
          </textarea>
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
          <button disabled="disabled" type="submit" class="btn btn-primary">Submit!</button>
        </div>
      </div>
    </form>
    <form class="flex-fill">
      <div class="row">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3">
          <div class="panel panel-default">
            <div class="panel-heading">
              <h4 class="panel-heading">Your Data</h4>
            </div>
            <div class="panel-body">
              <p>Mail:</p>
              <p>Password:</p>
              <p>Age:</p>
              <p>Description:</p>
              <p><strong>Skill Set?</strong></p>
              <ul>
                <li>C#</li>
                <li>JavaScript</li>
              </ul>
              <p>Gender:</p>
              <p>Country:</p>
            </div>
          </div>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
import resources from './assets/resources.json';

export default {
  name: 'App',
  data() {
    return {
      genders: resources.genders,
      countries: resources.countries,
      formData: {
        email: '',
        password: '',
        age: '',
        description: '',
        skillSet: [], // Когато имаме чек бокс, променливата трябва да е масив.
        gender: '',
        country: 'Bulgaria'
      }
    }
  },
  computed: {
    skillSets() {
      return resources.skillSets;
    }
  },
  components: {
    
  }
}
</script>

<style>
  @import url("https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css");
</style>
