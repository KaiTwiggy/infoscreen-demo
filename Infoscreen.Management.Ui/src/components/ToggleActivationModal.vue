<template>
    <form action="">
        <div class="modal-card">
            <header class="modal-card-head">
              <p class="modal-card-title">Toggle Slide activity ?</p>
            </header>
            <section class="modal-card-body">
                <p>Do you wanna toggle slide activity ?</p>
            </section>
            <footer class="modal-card-foot">
                <button class="button" type="button" @click="$parent.close()">Cancel</button>
                <button @click="toggleActivation(slideId)" class="button is-primary">Toggle</button>
            </footer>
        </div>
    </form>
</template>

<script>
import axios from 'axios'
import * as constants from '../constants'

export default {
  name: 'ToggleActivationModal',
  props: ['slideId'],
  methods: {
    toggleActivation (slideId) {
      let self = this
      axios
        .get(constants.API_BASEURL + '/api/slide/toggleActivation/' + slideId)
        .then(function () {
          self.$emit('close')
        })
    }
  }
}
</script>

<style scoped>
.modal-card {
  width: auto;
}
</style>
