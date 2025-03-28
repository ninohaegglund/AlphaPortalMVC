document.addEventListener('DOMContentLoaded', () => {
    
    initOpenModals();
    initCloseButtons();
    initForms();
    initDropdowns();
   

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

            if (!dropdown.classList.contains('hidden')) {
                dropdown.classList.add('hidden');
                return;
            }

            //else it's for the project dropdown
            let rect = button.getBoundingClientRect();
            dropdown.classList.remove('hidden');
            let dropdownWidth = dropdown.offsetWidth;
            dropdown.classList.add('hidden');

            dropdown.style.top = `${rect.bottom + window.scrollY}px`;
            dropdown.style.left = `${rect.left + window.scrollX - dropdownWidth + 20}px`;

            
            dropdown.classList.toggle("hidden");
        });
    });

    document.addEventListener("click", (event) => {
        const loginPartialContainer = document.getElementById("loginPartialContainer");
        const dropwdownPartialContainer = document.getElementById("dropdownPartialContainer");

        if (loginPartialContainer && !loginPartialContainer.contains(event.target) && !event.target.closest('[data-dropdown="true"]')) {
            loginPartialContainer.classList.add("hidden");
        }
        if (dropwdownPartialContainer && !dropwdownPartialContainer.contains(event.target) && !event.target.closest('[data-dropdown="true"]')) {
            dropwdownPartialContainer.classList.add("hidden");
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