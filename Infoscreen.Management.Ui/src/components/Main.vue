<template>
  <div>
    <section>
      <div class="container">
        <b-table :data="data" :loading="loading">
            <template slot-scope="props">
                <b-table-column label="ID" width="80" numeric >
                    {{ props.row.id }}
                </b-table-column>

                <b-table-column label="Type">
                    {{ props.row.cardType }}
                </b-table-column>

                <b-table-column label="Name">
                    {{ props.row.name }}
                </b-table-column>

                <b-table-column label="Active">
                    {{ props.row.isActive }}
                </b-table-column>

                <b-table-column label="Actions">
                    <span @click="openDeleteModal(props.row.id)"><b-icon icon="delete" /></span>
                    <span @click="openToggleActivationModal(props.row.id)">
                      <b-icon v-if="props.row.isActive" icon="minus-circle" type="is-green" />
                      <b-icon v-if="!props.row.isActive" icon="minus-circle" type="is-danger" />
                    </span>
                </b-table-column>
            </template>
        </b-table>
      </div>
    </section>
    <div class="container has-text-centered">
      <a @click="updateDevices" class="button is-primary is-medium">Update Devices</a>
    </div>
  </div>
</template>

<script>
import DeleteSlideModal from './DeleteSlideModal'
import ToggleActivationModal from './ToggleActivationModal'
import * as constants from '../constants'
import axios from 'axios'

var modalControls = {
  isDeleteSlideModalActive: false,
  isDeactivateSlideModalActive: false
}

export default {
  name: 'Main',
  data () {
    return {
      data: [],
      modalControls: modalControls
    }
  },
  methods: {
    updateDevices () {
      axios
        .get(constants.API_BASEURL + '/api/Websocket/UpdateSlides')
        .then(function (response) {
          console.log(response)
        })
        .catch(function (error) {
          console.log(error)
        })
    },
    openDeleteModal (slideId) {
      this.$modal.open({
        parent: this,
        component: DeleteSlideModal,
        hasModalCard: true,
        props: { slideId }
      })
    },
    openToggleActivationModal (slideId) {
      this.$modal.open({
        parent: this,
        component: ToggleActivationModal,
        hasModalCard: true,
        props: { slideId }
      })
    },
    loadAsyncData () {
      this.loading = true
      axios.get(constants.API_BASEURL + '/api/slide').then(
        ({ data }) => {
          this.data = []
          data.forEach(item => this.data.push(item))
          this.loading = false
        },
        response => {
          this.data = []
          this.total = 0
          this.loading = false
        }
      )
    }
  },
  mounted () {
    this.loadAsyncData()
  }
}
</script>

<style scoped>
h1,
h2 {
  font-weight: normal;
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
</style>
