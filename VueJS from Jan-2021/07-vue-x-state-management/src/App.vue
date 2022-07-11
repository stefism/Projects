<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png">
    <h2>The counter is: {{ counter }}. Double is: {{ double }}</h2>
    <h2>The counter is: {{ getCounter }}. Double is: {{ getDouble }}</h2>
    <button @click="incrementCount">Add 1</button>
    <button @click="getData">Fetch data</button>

    <p v-if="areCharactersLoading">Characters loading ...</p>

    <div>
      <label for="mgs">Type something </label>
      <input name="msg" type="text" v-model="message">
      <p>{{ message }}</p>
    </div>

    <div>
      <h2>Character Info:</h2>
      <p>Name: {{ userData.name }}</p>
      <button @click="loadUser">Load user</button>
    </div>

    <HelloWorld msg="Welcome to Your Vue.js App"/>
  </div>
</template>

<script>
import HelloWorld from './components/HelloWorld.vue';
import { mapGetters } from 'vuex';

export default {
  name: 'App',
  components: {
    HelloWorld
  },
  computed: {
    // Нещата, които взимаме от стора, трябва да са компютед пропертита, за да може автоматично да се отрази промяната, след като се променят.
    counter() {
      return this.$store.getters.getCounter;
    },
    double() {
      return this.$store.getters.getDouble;
    },
    areCharactersLoading() {
      return this.$store.getters.getLoadingState;
    },
     //Вместо да пишем отделен метод за всеки гетър и да го връщаме, имаме помощна функция mapGetters, която се импортира от vuex и с нея става по-кратко импортирането. После разбира се, където ги ползваме, трябва да им зададем тези имена, които са в mapGetters функцията.
     ...mapGetters(['getCounter', 'getDouble', 'getLoadingState']), // Това замества горните три пропертита, които са написани ръчно да връщат гетърите.
     //Освен mapGetters, имаме и mapMutations и mapActions.

     message: {
      get() {
        return this.$store.getters.message;
      },
      set(value) {
        this.$store.commit('message', value);
      }
      //Когато имаме инпут поле и изкаме да го вържем с v-model (Ви модел беше двупосочен байндинг на променливи в стейта. Когато напишем нещо в инпут полето, то ще се запише в променливата на стора.), за да го вържем със стора, трябва да направим компютед проперти, което да има гетер и сетер. В гетера го взимаме от глобалния стейт, а в сетера го записваме в глобалния стейт. Съответно в стейта трябва си имаме за това проперти променлива, гетер и мутатор.
     },
     userData() {
      return this.$store.getters['userModule/userData']; //Тук пишем първо името на модула, така, както сме го импортнали в главния стейт и после, черта, името на данните, които сме подали през гетера на модула. Това важи и за екшъните, мутаторите и т. н.
     }
  },
  methods: {
    incrementCount() {
      this.$store.commit('increment', { name: 'New name' });
      //.commit е ключова дума и с нея викаме мутатора, който сме написали в стора.
      //Ако искаме да променим нещо в стора, като втори параметър изпращаме payload, като той е обект, защото можем да изпратим само един payload.
    },
    getData() {
      this.$store.dispatch('getAllCharacters'); //Когато викаме екшъни използваме .dispatch, когато викаме мутатории използваме .commit.
    },
    loadUser() {
      this.$store.dispatch('userModule/getUser', this.counter);
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
