function constructionCrew(workerObject) {
    if (workerObject.dizziness) {
        workerObject.levelOfHydrated += (0.1 * workerObject.weight) * workerObject.experience;
        workerObject.dizziness = false;
    }

    return workerObject;
}

console.log(constructionCrew(
    { weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true }
  ));