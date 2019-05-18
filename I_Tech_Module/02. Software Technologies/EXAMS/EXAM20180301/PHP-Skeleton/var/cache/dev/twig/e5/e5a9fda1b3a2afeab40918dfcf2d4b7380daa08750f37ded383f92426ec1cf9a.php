<?php

/* :project:index.html.twig */
class __TwigTemplate_cf27bdab4def7a1505caf8086f50ac9f805b5803ef626d6de7b66e5a94f31449 extends Twig_Template
{
    public function __construct(Twig_Environment $env)
    {
        parent::__construct($env);

        // line 1
        $this->parent = $this->loadTemplate("base.html.twig", ":project:index.html.twig", 1);
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
        $__internal_69e6a4572424d876bc905d9e48ba3eb8280b1e554acdfec55556b47c2feabb7c = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_69e6a4572424d876bc905d9e48ba3eb8280b1e554acdfec55556b47c2feabb7c->enter($__internal_69e6a4572424d876bc905d9e48ba3eb8280b1e554acdfec55556b47c2feabb7c_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", ":project:index.html.twig"));

        $__internal_a1ef1d24ab64a79af8daf50e8a35bd97b49f8363e52286c2a1e3540e6cdc2e4e = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_a1ef1d24ab64a79af8daf50e8a35bd97b49f8363e52286c2a1e3540e6cdc2e4e->enter($__internal_a1ef1d24ab64a79af8daf50e8a35bd97b49f8363e52286c2a1e3540e6cdc2e4e_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", ":project:index.html.twig"));

        $this->parent->display($context, array_merge($this->blocks, $blocks));
        
        $__internal_69e6a4572424d876bc905d9e48ba3eb8280b1e554acdfec55556b47c2feabb7c->leave($__internal_69e6a4572424d876bc905d9e48ba3eb8280b1e554acdfec55556b47c2feabb7c_prof);

        
        $__internal_a1ef1d24ab64a79af8daf50e8a35bd97b49f8363e52286c2a1e3540e6cdc2e4e->leave($__internal_a1ef1d24ab64a79af8daf50e8a35bd97b49f8363e52286c2a1e3540e6cdc2e4e_prof);

    }

    // line 3
    public function block_main($context, array $blocks = array())
    {
        $__internal_803ce21e204927942537036285838cdb5f860623758265ee4caed076c008418d = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_803ce21e204927942537036285838cdb5f860623758265ee4caed076c008418d->enter($__internal_803ce21e204927942537036285838cdb5f860623758265ee4caed076c008418d_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "main"));

        $__internal_b8372e9bb3e92a9d5fa0cc7262d60285cb95a64d97692bba2499c6d2a01cb9bb = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_b8372e9bb3e92a9d5fa0cc7262d60285cb95a64d97692bba2499c6d2a01cb9bb->enter($__internal_b8372e9bb3e92a9d5fa0cc7262d60285cb95a64d97692bba2499c6d2a01cb9bb_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "main"));

        // line 4
        echo "<div class=\"wrapper\">
    <div class=\"button-holder\">
        <a type=\"button\" href=\"/create\" class=\"log-button\">Create New Project</a>
    </div>
    <div class=\"content\">
        <div class=\"header\">
            <div class=\"project-label\">Project</div>
            <div class=\"budget-label\">Budget</div>
            <div class=\"actions-label\">Actions</div>
        </div>
        <div class=\"main\">
            ";
        // line 15
        $context['_parent'] = $context;
        $context['_seq'] = twig_ensure_traversable(($context["projects"] ?? $this->getContext($context, "projects")));
        foreach ($context['_seq'] as $context["_key"] => $context["project"]) {
            // line 16
            echo "                <div class=\"project\">
                    <div class=\"project-title\">
                        ";
            // line 18
            echo twig_escape_filter($this->env, $this->getAttribute($context["project"], "title", array()), "html", null, true);
            echo "
                    </div>
                    <div class=\"project-budget\">
                        ";
            // line 21
            echo twig_escape_filter($this->env, $this->getAttribute($context["project"], "budget", array()), "html", null, true);
            echo "
                    </div>
                    <div class=\"project-actions\">
                        <a type=\"button\" href=\"";
            // line 24
            echo twig_escape_filter($this->env, $this->env->getExtension('Symfony\Bridge\Twig\Extension\RoutingExtension')->getPath("edit", array("id" => $this->getAttribute($context["project"], "id", array()))), "html", null, true);
            echo "\" class=\"edit-button\">Edit</a>
                        <a type=\"button\" href=\"";
            // line 25
            echo twig_escape_filter($this->env, $this->env->getExtension('Symfony\Bridge\Twig\Extension\RoutingExtension')->getPath("delete", array("id" => $this->getAttribute($context["project"], "id", array()))), "html", null, true);
            echo "\" class=\"delete-button\">Delete</a>
                    </div>
                </div>
            ";
        }
        $_parent = $context['_parent'];
        unset($context['_seq'], $context['_iterated'], $context['_key'], $context['project'], $context['_parent'], $context['loop']);
        $context = array_intersect_key($context, $_parent) + $_parent;
        // line 29
        echo "        </div>
    </div>
</div>
";
        
        $__internal_b8372e9bb3e92a9d5fa0cc7262d60285cb95a64d97692bba2499c6d2a01cb9bb->leave($__internal_b8372e9bb3e92a9d5fa0cc7262d60285cb95a64d97692bba2499c6d2a01cb9bb_prof);

        
        $__internal_803ce21e204927942537036285838cdb5f860623758265ee4caed076c008418d->leave($__internal_803ce21e204927942537036285838cdb5f860623758265ee4caed076c008418d_prof);

    }

    public function getTemplateName()
    {
        return ":project:index.html.twig";
    }

    public function isTraitable()
    {
        return false;
    }

    public function getDebugInfo()
    {
        return array (  96 => 29,  86 => 25,  82 => 24,  76 => 21,  70 => 18,  66 => 16,  62 => 15,  49 => 4,  40 => 3,  11 => 1,);
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
    <div class=\"button-holder\">
        <a type=\"button\" href=\"/create\" class=\"log-button\">Create New Project</a>
    </div>
    <div class=\"content\">
        <div class=\"header\">
            <div class=\"project-label\">Project</div>
            <div class=\"budget-label\">Budget</div>
            <div class=\"actions-label\">Actions</div>
        </div>
        <div class=\"main\">
            {% for project in projects %}
                <div class=\"project\">
                    <div class=\"project-title\">
                        {{ project.title }}
                    </div>
                    <div class=\"project-budget\">
                        {{ project.budget }}
                    </div>
                    <div class=\"project-actions\">
                        <a type=\"button\" href=\"{{ path('edit', {id: project.id}) }}\" class=\"edit-button\">Edit</a>
                        <a type=\"button\" href=\"{{ path('delete', {id: project.id}) }}\" class=\"delete-button\">Delete</a>
                    </div>
                </div>
            {% endfor %}
        </div>
    </div>
</div>
{% endblock %}", ":project:index.html.twig", "H:\\EXAM\\PHP-Skeleton\\app/Resources\\views/project/index.html.twig");
    }
}
