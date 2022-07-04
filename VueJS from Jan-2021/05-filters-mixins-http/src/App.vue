<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png" />

    <el-button type="primary">Primary</el-button>
    <el-button type="success">Success</el-button>
    <el-button type="info">Info</el-button>
    <!-- Тези бутони идват от библиотеката ElementUI. Нея също я инсталираме глобално в main.js файла. -->

    <CharactersTable />

    <EpisodeTable />

    {{ message }}
    <hr />
    {{ message | reverse }}
    <hr />
    {{ message | rev-global }}
    <!-- Филтрите се ползват с този синтаксис. Първо стринга върху който се прилагаме филтъра, след това тръба и името на филтъра. -->
    <hr />
    <p v-highlight="red">{{ message }}</p>
    <!-- v-highlight - къстъм директива. Регистрира се глобално в main.js файла. -->

    <hr />
    <input v-event:input="inputHandler" type="text" />
  </div>
</template>

<script>
import CharactersTable from './components/Characters-table.vue';
import EpisodeTable from './components/Episodes-table.vue';

export default {
  name: "App",
  data() {
    return {
      message: "Hi Vue",
      red: "red"
    };
  },
  filters: {
    reverse(value) {
      return value.split("").reverse().join("");
      //Филтрите се използват най-често за форматиране на стрингове.
      //Мога да бъдат регистрирани глобално и да се ползват за всички компоненти. Това става в main.js файла.
      //Може да прилагаме повече от един филтър едновременно.
    },
  },
  methods: {
    inputHandler(e) {
      console.log("inputHandler event: ", e);
    },
  },
  components: {
    CharactersTable, EpisodeTable
  }
};
</script>

<style></style>
