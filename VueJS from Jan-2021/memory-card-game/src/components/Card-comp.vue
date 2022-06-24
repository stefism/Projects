<template>
  <li
    class="memory-card"
    :class="{ flip: card.visible, 'disable-card': card.matched }"
    :data-framework="card.name"
    @click="onCardClick(card, index)"
  >
    <img class="front-face" svg-inline :src="card.image" :alt="card.name" />
    <img class="back-face" src="../assets/img/js-badge.svg" :alt="card.name" />
  </li>
</template>

<script>
export default {
    props: {
        card: {
            type: Object,
            required: true
        },
        index: {
            type: Number,
            required: true
        }
        // Първи път подаваме card и index тук, защото са необходими както на елемента, така и на евента.
    },
    methods: {
        onCardClick(card, index) {
            this.$emit("onCardClick", card, index);
            //Тук нагоре освен евента, предаваме обратно и card и index. Подаваме втори път card и index и тук, като част от евента.
        }
    }
};
</script>

<style>
</style>