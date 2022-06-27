<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png">

    <keep-alive>
      <!-- keep-alive -> Keeping data values alive as you switch -->
      <component :is="component" />
    </keep-alive>

    <button @click="toggle">Toggle</button>
    
    <SlotComponent msg="Welcome to Your Vue.js App">
      <span>Slot test - default slot</span>
      <!-- Ето тук пъхаме нещото, в случая надписа "Slot test - default slot", който ще се визуализира като h2 таг в SlotComponent-а (чайлд компонента). За целта в чайлд компонента, трябва да имаме тага <slot/>. Иначе няма да се визуализира. Можем да подаваме в слота html. В случая ще имаме в крайния html таг h2 в който ще имаме <span>Slot test</span>. Когато слота не е именуван се приема за дефолтен. -->
      <div slot-scope="props" slot="personName">
        <span>Slot 2 - named slot. Gender: {{props.char.gender}}</span>
      </div>
      <!-- Когато имаме повече от един слот, в чайлд трябва да им дадем име -> <slot :char="item" name="personName"/> - ето така, а тук в парента казваме в кой слот ще пъхаме нещо със slot="personName". Тук името трябва да е същото както името което сме дали на слота в чайлд компонента. -->
      <!-- Трябва да се внимава къде слагаме пропсовете. Ако ги сложим slot-scope="props" slot="personName" на span елемента, няма да работи и ще хвърля грешка. В случая "props" е просто име, което можем да кръстим както с искаме. То оказва в кой "скоуп" работим или просто името на скоупа, а "char" идва от чайлд компонента. Както сме го кръстили в чайлда, така трябва да го напишем и тук и след това името на пропертито. -->
    </SlotComponent>
  </div>
</template>

<script>
import SlotComponent from './components/Slot-comp.vue';
import DynamicComp1 from './components/Dynamic1.vue';
import DynamicComp2 from './components/Dynamic2.vue';

export default {
  name: 'App',
  components: {
    SlotComponent,
    DynamicComp1,
    DynamicComp2

  },
  data() {
    return {
      component: "DynamicComp2"
    }
  },
  methods: {
    toggle(){
      if (this.component == DynamicComp1) {
        this.component = DynamicComp2;
      } else {
        this.component = DynamicComp1;
      }
    }
  }
}
</script>

<style>

</style>
