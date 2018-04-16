<template>
<div class="create">
    <div class="row">
        <!-- Modal -->
        <div id="createModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <!-- Modal Content -->
                <div class="modal-content">
                    <div class="modal-header">
                            <button type="button" class="close btn btn-default" data-dismiss="modal">&times;</button>
                            <a @click="toggleForm" v-if="createForm">Create Keep</a>
                            <a @click="toggleForm" v-else>Create Vault</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</template>

<script>
</script>

<style>

</style>