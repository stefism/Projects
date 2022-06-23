<template>
  <div>
    <h1>Enter text</h1>
    <input type="text" @input="handleEvent($event)" @keyup.up="onUpKey">
    <!-- $event - така подаваме евента на функцията. С доларче отпред. Евента също така се подава по подразбиране, както при стандартния js. Ако напишем името на функцията без скоби, пак ще се подаде. -->
    <!-- @keyup.up - имаме възможност да закачаме някои от евентите, само към специфичен клавиш. Горе, отпускането на бутон е закачено само към стрелка нагоре и ще се случи само при натискането на този бутон. -->
    <form @submit.prevent="onFormSubmit">

    </form>
    <!-- Ако имаме форма, можем да напишем на субмит евента .prevent и това е равносилно на .preventDefault долу във функцията. Така не е необходимо да подаваме евента, само за да може долу да му кажем .preventDefault -->
    <p>Value is: {{value}}</p>
    <p>Стрелката нагоре е натисната {{keyUp}} пъти.</p>
  </div>
</template>

<script>
export default {
  name: 'App',
  data() {
    return {
      value: '',
      keyUp: 0
    };
  },
  methods: {
    handleEvent(event) {
      console.log(event);
      this.value = event.target.value;
    },
    onFormSubmit() {

    },
    onUpKey() {
      this.keyUp++;
      console.log('Стрелка нагоре е натисната.');
    }
  }
};
</script>

<style>
  
</style>
