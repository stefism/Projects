<template>
  <div class="results" v-if="stopGame">
    <p v-if="areAllFound" class="win">YOU WIN :)</p>
    <p v-else class="fail">YOU Fail.</p>
  </div>
</template>

<script>
export default {
    props: {
      stopGame: {
        type: Boolean,
        required: true
      },
      areAllFound: {
        type: Boolean,
        required: true
      }
    }
};
</script>

<style>
</style>