<template>
<div>
  <ul>
    <li v-for="(vegie, index) in vegetables" :key="index">
      index: {{index}}, vegie: {{vegie}}
    </li>
  </ul>
  <!-- Задължително трябва да имаме уникален индекс, когато въртим елементи -->

  <hr/>

  <ul>
    <li 
      class="list"
      :class="{
        fruit: item.type == 'fruit',
        vegetable: item.type == 'vegetable'
      }"
      v-for="(item, index) in listOfItems" 
      :key="index">

      <!-- :class - байндваме се (закачаме се) към клас. Ако пропертито .type на item е fruit, ще добавим към лист айтем елемента клас fruit. Съответно ако пропертито .type на item е vegetable ще добавим към li елемента клас vegetable. Класовете са дефинирани по-долу и правят фона на елемента да е със зададен цвят. -->
      index: {{index}}, vegie: {{item.name}}

    </li>
  </ul>

  <hr/>

  <ul>
    <li 
      class="list"
      :class="[item.type == 'fruit' ? 'fruit' : 'vegetable']"
      v-for="(item, index) in listOfItems" 
      :key="index">

      <!-- Тук използваме :class като вместо обект, както горе, му слагаме масив и в него с тернарен оператор му казваме кой клас да сложи. Прави същото като горното. Ако имаме само две стойности, така е по-четимо. -->
      index: {{index}}, vegie: {{item.name}}
      
    </li>
  </ul>

  <hr/>

  <ul>
    <li 
      class="list"
      :class="{
        fruit: isFruit(item.type),
        vegetable: !isFruit(item.type)
      }"
      v-for="(item, index) in listOfItems" 
      :key="index">

      <!-- Тук в :class ползваме функция. Прави същото както горните. -->
      index: {{index}}, vegie: {{item.name}}

    </li>
  </ul>
</div>
</template>

<script>
export default {
  name: 'App',
  data() {
    return {
      listOfItems: [
        {
          type: 'vegetable',
          name: 'apple'
        },
        {
          type: 'vegetable',
          name: 'apricot'
        },
        {
          type: 'fruit',
          name: 'cherry'
        },
        {
          type: 'vegetable',
          name: 'cranberry'
        },
        {
          type: 'fruit',
          name: 'mango'
        },
        {
          type: 'fruit',
          name: 'raspberry'
        },
      ],
      vegetables: [
        "apple",
        "apricot",
        "cherry",
        "cranberry",
        "mango",
        "raspberry"
      ]
    };
  },
  methods: {
    isFruit(type) {
      return type == 'fruit';
    }
  }
};
</script>

<style>
  .list {
    list-style: georgian;
    border: 2px solid black;
    margin-bottom: 0.5rem;
  }

  .vegetable {
    background-color: coral;
  }

  .fruit {
    background-color: chartreuse;
  }
</style>
