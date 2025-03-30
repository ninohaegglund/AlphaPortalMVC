document.addEventListener('DOMContentLoaded', () => {
    
    initOpenModals();
    initCloseButtons();
    initForms();
    initDropdowns();
    initDeleteButtons();
    initDropdownToggles();

})
function clearFormErrorMessages(form) {
    form.querySelectorAll('[data-val="true"]').forEach(input => {
        input.classList.remove('input-validation-error')
    })

    form.querySelectorAll('[data-valmsg-for]').forEach(span => {
        span.innerText = ''
        span.classList.remove('field-validation-error')
    })
}
function addFormErrorMessages(errors, form) {
    Object.keys(errors).forEach(key => {
        const input = form.querySelector(`[name="${key}"]`)
        if (input) {
            input.classList.add('input-validation-error')
        }

        const span = form.querySelector(`[data-valmsg-for="${key}"]`)
        if (span) {
            span.innerText = errors[key].join(' ')
            span.classList.add('field-validation-error')
        }
    })
}
function initForms() {
    const forms = document.querySelectorAll('form')
    forms.forEach(form => {
        if (form.id == "logoutForm") return;

        form.addEventListener('submit', async (e) => {
            e.preventDefault()

            clearFormErrorMessages(form)

            const formData = new FormData(form)

            try {
                const res = await fetch(form.action, {
                    method: 'post',
                    body: formData
                })

                if (res.ok) {
                    const modal = form.closest('.modal')
                    if (modal)
                        closeModal(modal)

                    window.location.reload()
                }
                else if (res.status === 400) {
                    const data = await res.json()
                    if (data.errors) {
                        addFormErrorMessages(data.errors, form)
                    }
                }
                else if (res.status === 409) {
                    alert('Client already exists')
                }
                else {
                    alert('Unable to create new Client')
                }

            }
            catch {

            }
        })
    })
}
function initDeleteButtons() {
    const deleteButtons = document.querySelectorAll(".delete-button");

    deleteButtons.forEach(button => {
        button.addEventListener("click", async function () {
            const projectId = this.getAttribute("data-project-id");

            if (!projectId) {
                console.error("Project ID is missing");
                return;
            }
            

            try {
                console.log(`Attempting to delete project with ID: ${projectId}`);
                const res = await fetch(`/admin/projects/${projectId}`, {
                    method: "DELETE"
                });

                if (res.ok) {
                    window.location.reload();
                } else {
                    alert("Failed to delete the project.");
                }
            } catch (error) {
                console.error("Error deleting project:", error);
            }
        });
    });
}
function initDropdownToggles() {

    // En metod som är genererad av ChatGPT 4, dess funktion är att
    // öppna och stänga dropdown-menyer som finns i projects.cshtml.
    const dropdownButtons = document.querySelectorAll(".more-avatar");

    dropdownButtons.forEach(button => {
        button.addEventListener("click", function () {
            const dropdownId = this.getAttribute("data-target"); 
            const dropdown = document.querySelector(dropdownId);

            if (!dropdown) {
                console.error("Dropdown not found for ID:", dropdownId);
                return;
            }

            const isAlreadyOpen = dropdown.style.display === "block";

          
            document.querySelectorAll(".more-dropdown-content").forEach(d => {
                d.style.display = "none";
            });

          
            if (!isAlreadyOpen) {
                dropdown.style.display = "block";
            }

        });
    });
    // Stänger dropdown när man klickar utanför
    document.addEventListener("click", function (event) {
        document.querySelectorAll(".more-dropdown-content").forEach(dropdown => {
            if (!dropdown.contains(event.target) && !event.target.closest(".more-avatar")) {
                dropdown.style.display = "none";
            }
        });
    });

}
function initDropdowns() {
    const dropdownButtons = document.querySelectorAll('[data-dropdown="true"]');

    dropdownButtons.forEach(button => {
        button.addEventListener('click', (event) => {
            event.stopPropagation();

            const target = button.getAttribute('data-target');
            const dropdown = document.querySelector(target);

            if (!dropdown) return;

            //normal toggle for logindropdown
            if (target === "#loginPartialContainer") {
                dropdown.classList.toggle('hidden');
                return;
            }

            
            dropdown.classList.toggle("hidden");
        });
    });

    document.addEventListener("click", (event) => {
        const loginPartialContainer = document.getElementById("loginPartialContainer");

        if (loginPartialContainer && !loginPartialContainer.contains(event.target) && !event.target.closest('[data-dropdown="true"]')) {
            loginPartialContainer.classList.add("hidden");
        }
       
    });
}
function initOpenModals() {
    const modalButtons = document.querySelectorAll('[data-modal="true"]')
    modalButtons.forEach(button => {
        button.addEventListener('click', () => {
            
            const target = button.getAttribute('data-target')
            const modal = document.querySelector(target)

            if (modal) {
                modal.classList.add('flex')
          
            }
        });
    });
}
function initCloseButtons() {
    const closeButtons = document.querySelectorAll('[data-close="true"]')
    closeButtons.forEach(button => {

        button.addEventListener('click', () => {
            const target = button.getAttribute('data-target')
            const targetElement = document.querySelector(target)

            if (targetElement) {
                if (targetElement.classList.contains('modal')) {
                    closeModal(targetElement)
                }
            }
        })
    })
}
function closeModal(modal) {
    if (modal) {
        modal.classList.remove('flex')

        modal.querySelectorAll('form').forEach(form => {
            form.reset()
        })
    }
}