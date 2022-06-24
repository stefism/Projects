<template>
  <div class="controls">
    <button class="btn" @click="onGameStart" :disabled="isGameStarted">
      Start new game
    </button>
    <button class="btn" @click="handleGameReset" :disabled="!isGameStarted">
      Reset game
    </button>
    <span class="counter">TIME LEFT: {{ counter }}</span>
  </div>
</template>

<script>
export default {
    props: {
        isGameStarted: {
            type: Boolean,
            required: true
        },
        counter: {
            type: Number,
            required: true
        }
    },
    methods: {
        onGameStart() {
            this.$emit("onGameStart");
        },
        handleGameReset() {
            this.$emit("handleGameReset");
        }
        //Когато трябва да подадем информация от чайлда към парента, използваме къстъм евенти. В случая в този компонент имаме два клик евента, които трябва да предадем към парент компонента, който в случая е App.vue. По този начин, с ключовата дума .$emit подаваме нагоре към парент компонента, двата евента от чаилд компонента.
    }
};
</script>

<style>
</style>