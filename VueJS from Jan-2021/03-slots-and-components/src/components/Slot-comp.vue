<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <h2><slot/></h2>
    <!-- Слота указва, че тук ще бъде пъхнато нещо от парент компонента. В случая като чайлд на h2 ще бъде пъхнато <span>Slot test</span>, което идва от парент компонента. -->

    <ul class="list">
      <li class="item" v-for="item in characters" :key="item.id">
        <img class="img" :src="item.image" />
        <p>{{item.name}}</p>
        <p>{{item.species}}</p>
        <slot :char="item" name="personName"/>
        <!-- Когато направим :char="item" казваме каква променлива ще се предаде нагоре към парента. В случая "char". (Можем да я кръстим както си искаме.) item пък е това, което прикачваме към променливата и това, което ще се предаде нагоре към парента. -->
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'SlotComponent',
  props: {
    msg: String
  },
  data() {
    return {
      characters: []
    };
  },
  methods: {
    async loadData() {
      const url = 'https://rickandmortyapi.com/api/character';
      const responce = await fetch(url);
      const data = await responce.json();
      this.characters = data.results;
      console.log('characters: ', this.characters);
    }
  },
  async created() { //Това е лайф сайкъл.
    await this.loadData();
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
.img {
  border-radius: 10%;
}
</style>
