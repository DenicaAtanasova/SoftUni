<?php

/* :project:create.html.twig */
class __TwigTemplate_554ce2a565e3f40b5aec014ba1dafbebaf1d412fdc82eed325a73c6bf41a5acb extends Twig_Template
{
    public function __construct(Twig_Environment $env)
    {
        parent::__construct($env);

        // line 1
        $this->parent = $this->loadTemplate("base.html.twig", ":project:create.html.twig", 1);
        $this->blocks = array(
            'main' => array($this, 'block_main'),
        );
    }

    protected function doGetParent(array $context)
    {
        return "base.html.twig";
    }

    protected function doDisplay(array $context, array $blocks = array())
    {
        $__internal_c9a879bc362d1dde9862d4e0789b647fbffaff096794906b9aa6177f0e490089 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_c9a879bc362d1dde9862d4e0789b647fbffaff096794906b9aa6177f0e490089->enter($__internal_c9a879bc362d1dde9862d4e0789b647fbffaff096794906b9aa6177f0e490089_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", ":project:create.html.twig"));

        $__internal_46d2a436c7209d3d63b0ac669710a4da27342a9c4e11e4c026b20b56c4364809 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_46d2a436c7209d3d63b0ac669710a4da27342a9c4e11e4c026b20b56c4364809->enter($__internal_46d2a436c7209d3d63b0ac669710a4da27342a9c4e11e4c026b20b56c4364809_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", ":project:create.html.twig"));

        $this->parent->display($context, array_merge($this->blocks, $blocks));
        
        $__internal_c9a879bc362d1dde9862d4e0789b647fbffaff096794906b9aa6177f0e490089->leave($__internal_c9a879bc362d1dde9862d4e0789b647fbffaff096794906b9aa6177f0e490089_prof);

        
        $__internal_46d2a436c7209d3d63b0ac669710a4da27342a9c4e11e4c026b20b56c4364809->leave($__internal_46d2a436c7209d3d63b0ac669710a4da27342a9c4e11e4c026b20b56c4364809_prof);

    }

    // line 3
    public function block_main($context, array $blocks = array())
    {
        $__internal_c80219e7a5ca8a96ae1b8a6fbaa63203ec949ef65bd136126e18cafb8b1f73a5 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_c80219e7a5ca8a96ae1b8a6fbaa63203ec949ef65bd136126e18cafb8b1f73a5->enter($__internal_c80219e7a5ca8a96ae1b8a6fbaa63203ec949ef65bd136126e18cafb8b1f73a5_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "main"));

        $__internal_4aa57295714f158cec07bc8599616770a2efcfc80e9538b88b1d91d29d8c5780 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_4aa57295714f158cec07bc8599616770a2efcfc80e9538b88b1d91d29d8c5780->enter($__internal_4aa57295714f158cec07bc8599616770a2efcfc80e9538b88b1d91d29d8c5780_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "main"));

        // line 4
        echo "<div class=\"wrapper\">
    <form class=\"project-create\" method=\"post\">
        <div class=\"create-header\">
            Create Project
        </div>
        <div class=\"create-title\">
            <div class=\"create-title-label\">Title</div>
            <input class=\"create-title-content\" name=\"project[title]\" />
        </div>
        <div class=\"create-description\">
            <div class=\"create-description-label\">Description</div>
            <textarea rows=\"3\" class=\"create-description-content\" name=\"project[description]\"></textarea>
        </div>
        <div class=\"create-budget\">
            <div class=\"create-budget-label\">Budget</div>
            <input type=\"number\" min=\"0\" class=\"create-budget-content\" name=\"project[budget]\" />
        </div>
        <div class=\"create-button-holder\">
            <button type=\"submit\" class=\"submit-button\">Create Project</button>
            <a type=\"button\" href=\"/\" class=\"back-button\">Back</a>
        </div>

        ";
        // line 26
        echo $this->env->getRuntime('Symfony\Bridge\Twig\Form\TwigRenderer')->searchAndRenderBlock($this->getAttribute(($context["form"] ?? $this->getContext($context, "form")), "_token", array()), 'row');
        echo "
    </form>
</div>
";
        
        $__internal_4aa57295714f158cec07bc8599616770a2efcfc80e9538b88b1d91d29d8c5780->leave($__internal_4aa57295714f158cec07bc8599616770a2efcfc80e9538b88b1d91d29d8c5780_prof);

        
        $__internal_c80219e7a5ca8a96ae1b8a6fbaa63203ec949ef65bd136126e18cafb8b1f73a5->leave($__internal_c80219e7a5ca8a96ae1b8a6fbaa63203ec949ef65bd136126e18cafb8b1f73a5_prof);

    }

    public function getTemplateName()
    {
        return ":project:create.html.twig";
    }

    public function isTraitable()
    {
        return false;
    }

    public function getDebugInfo()
    {
        return array (  73 => 26,  49 => 4,  40 => 3,  11 => 1,);
    }

    /** @deprecated since 1.27 (to be removed in 2.0). Use getSourceContext() instead */
    public function getSource()
    {
        @trigger_error('The '.__METHOD__.' method is deprecated since version 1.27 and will be removed in 2.0. Use getSourceContext() instead.', E_USER_DEPRECATED);

        return $this->getSourceContext()->getCode();
    }

    public function getSourceContext()
    {
        return new Twig_Source("{% extends \"base.html.twig\" %}

{% block main %}
<div class=\"wrapper\">
    <form class=\"project-create\" method=\"post\">
        <div class=\"create-header\">
            Create Project
        </div>
        <div class=\"create-title\">
            <div class=\"create-title-label\">Title</div>
            <input class=\"create-title-content\" name=\"project[title]\" />
        </div>
        <div class=\"create-description\">
            <div class=\"create-description-label\">Description</div>
            <textarea rows=\"3\" class=\"create-description-content\" name=\"project[description]\"></textarea>
        </div>
        <div class=\"create-budget\">
            <div class=\"create-budget-label\">Budget</div>
            <input type=\"number\" min=\"0\" class=\"create-budget-content\" name=\"project[budget]\" />
        </div>
        <div class=\"create-button-holder\">
            <button type=\"submit\" class=\"submit-button\">Create Project</button>
            <a type=\"button\" href=\"/\" class=\"back-button\">Back</a>
        </div>

        {{ form_row(form._token) }}
    </form>
</div>
{% endblock %}", ":project:create.html.twig", "H:\\EXAM\\PHP-Skeleton\\app/Resources\\views/project/create.html.twig");
    }
}
