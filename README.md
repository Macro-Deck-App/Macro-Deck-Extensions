## Macro Deck Extension Store
This repository is the build manifest for the Macro Deck 2 Extension Store.

All artifacts to include in Macro Deck must be pulled into this repository for building/packaging.

### How to publish your content

#### Workflow Process
1. Fork this repository
2. On your fork, click on the `Actions` tab
3. Click on the `Add/Update Extension` workflow

   > **Note:** if on mobile click the `Select workflow` button first
   
4. Click on `Run workflow` button
5. Fill in the details and click the green `Run workflow` button under the fields
6. Open the PR that is created, accept and merge it
7. On your main branch, create a PR to the parent repository
  - This is required due to permissions via actions being more strict than the web UI
